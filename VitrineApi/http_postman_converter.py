print("hello !")

import json
import re

if __name__ == "__main__":

    def parse_http_file(filepath):
        with open(filepath, "r", encoding="utf-8") as f:
            content = f.read()

        # Séparer les requêtes avec ### ou lignes vides multiples
        requests = re.split(r"###\s*", content)
        collection_items = []

        for req in requests:
            req = req.strip()
            if not req:
                continue

            # Extraire la méthode et l'URL
            match = re.match(r"(GET|POST|PUT|DELETE)\s+(.+)", req)
            if not match:
                continue
            method, url = match.groups()

            # Extraire les headers
            headers = re.findall(r"^(.*?):\s*(.*?)$", req, re.MULTILINE)

            # Extraire le body (si JSON)
            body_match = re.search(r"\{[\s\S]*\}$", req)
            body = body_match.group(0) if body_match else None

            postman_item = {
                "name": f"{method} {url}",
                "request": {
                    "method": method,
                    "header": [
                        {"key": h[0], "value": h[1]}
                        for h in headers
                        if h[0].lower() != "content-type"
                    ],
                    "url": {"raw": url, "host": [url]},
                },
            }

            if body:
                postman_item["request"]["body"] = {
                    "mode": "raw",
                    "raw": body,
                    "options": {"raw": {"language": "json"}},
                }

            collection_items.append(postman_item)

        # Structure globale de collection
        postman_collection = {
            "info": {
                "name": "Generated from HTTP file",
                "schema": "https://schema.getpostman.com/json/collection/v2.1.0/collection.json",
            },
            "item": collection_items,
        }

        return postman_collection

    def export_to_postman_json(input_http_file, output_json_file):
        collection = parse_http_file(input_http_file)
        with open(output_json_file, "w", encoding="utf-8") as f:
            json.dump(collection, f, indent=2)
        print(f"✅ Exporté vers {output_json_file}")

    # Exemple d'utilisation
    # export_to_postman_json("VitrineApi.http", "VitrineApi_postman_collection.json")

    def postman_to_http(postman_json_path, output_file_path):
        with open(postman_json_path, "r") as f:
            collection = json.load(f)

        with open(output_file_path, "w") as output_file:
            for item in collection["item"]:
                # On suppose que chaque élément contient un objet "request" avec les détails de la requête
                request = item["request"]
                method = request["method"]
                url = request["url"]["raw"]
                headers = request.get("header", [])
                body = request.get("body", {}).get("raw", "")

                # Écrire la méthode HTTP et l'URL
                output_file.write(f"{method} {url}\n")

                # Ajouter les en-têtes
                for header in headers:
                    output_file.write(f"{header['key']}: {header['value']}\n")

                # Ajouter le corps de la requête si présent
                if body:
                    output_file.write(f"\n{body}\n")

                output_file.write("\n\n")

        postman_json_path = (
            "path_to_postman_collection.json"  # Chemin vers ton fichier JSON Postman
        )
        output_file_path = "output_file.http"  # Chemin vers le fichier de sortie
        postman_to_http(postman_json_path, output_file_path)
        print(
            f"Conversion terminée. Le fichier HTTP a été sauvegardé dans {output_file_path}."
        )
