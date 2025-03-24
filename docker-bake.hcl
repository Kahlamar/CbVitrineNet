group "default" {
  targets = ["cbvitrinenet", "vitrineapi"]
}

target "cbvitrinenet" {
  context = "."
  dockerfile = "CbVitrineNet/Dockerfile"
  tags = ["cbvitrinenet:latest"]
}

target "vitrineapi" {
  context = "."
  dockerfile = "VitrineApi/Dockerfile"
  tags = ["vitrineapi:latest"]
}
