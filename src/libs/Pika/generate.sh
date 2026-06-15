#!/usr/bin/env bash
set -euo pipefail

# Manual OpenAPI spec — reverse-engineered from Pika-Skills Python client
# Auth: DevKey prefix via Authorized hook (uses Bearer for constructor generation)

dotnet tool install --global autosdk.cli --prerelease

rm -rf Generated

autosdk generate openapi.yaml \
  --namespace Pika \
  --clientClassName PikaClient \
  --targetFramework net10.0 \
  --output Generated \
  --exclude-deprecated-operations \
  --security-scheme Http:Header:Bearer

rm -rf ../../cli/Pika.CLI

autosdk cli-project openapi.yaml \
  --output ../../cli/Pika.CLI \
  --sdk-project ../../libs/Pika/Pika.csproj \
  --targetFramework net10.0 \
  --namespace Pika \
  --clientClassName PikaClient \
  --package-id Pika.CLI \
  --tool-command-name pika \
  --user-secrets-id Pika.CLI \
  --api-key-env-var PIKA_API_KEY \
  --base-url-env-var PIKA_BASE_URL \
  --cli-credential-file \
  --exclude-deprecated-operations \
  --security-scheme Http:Header:Bearer
