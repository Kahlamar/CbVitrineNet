print("hello !")

import json
import re


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
