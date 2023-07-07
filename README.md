# Quickjournal - Backend

Simple development journaling app focused on quick note taking.

Built with .NET WebAPI + Postgres

# Docker-compose

Fill out the .env using .env_SAMPLE

## Regarding EF

Use user-secrets to store secrets. Use key `Quickjournal:ConnectionString` Will need a connectionString that looks something like this:

`Host=<HOST>;Database=<DATABASE>;Username=<USERNAME>;Password=<PASSWORD>;Port=<PORT>`
