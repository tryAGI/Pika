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
