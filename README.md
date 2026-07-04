# IYS Platform

IYS is the initial scaffold for a modern, AI-ready manufacturing and ERP-style platform tailored for Turkish manufacturers, warehouses, and cross-border trade operations.

The repository starts with a **.NET 8 modular monolith** that favors fast delivery today and clean extraction paths later for SaaS, integrations, and AI workloads.

## Product vision

Build a practical factory operations platform that helps Turkish manufacturers replace spreadsheet-heavy and legacy ERP workflows with:

- live inventory visibility
- warehouse and stock traceability
- supplier and purchasing coordination
- manager dashboards and operational reporting
- AI-assisted recommendations and anomaly detection
- Microsoft-friendly integration paths, including optional Dynamics 365 Business Central connectivity

## Architecture at a glance

- **Backend**: ASP.NET Core Web API (`src/Api/Iys.Api`)
- **Module style**: modular monolith with bounded modules in separate projects
- **Shared building blocks**: `src/BuildingBlocks/Iys.SharedKernel`
- **Primary modules**
  - `Catalog` — item and product master data
  - `Inventory` — warehouses, balances, and stock movement traceability
  - `Purchasing` — suppliers and purchasing flow seeds
  - `Reporting` — dashboard/reporting foundation
  - `Ai` — AI capability registry and extension points
- **Deployment direction**: Azure-hosted SaaS first, with room for hybrid/customer-specific integrations later

More detail lives in [`docs/architecture.md`](./docs/architecture.md).

## Why this is different from legacy ERP-style systems

This scaffold is intentionally shaped away from older local ERP patterns:

- **modular and API-first**, not a single tightly coupled codebase
- **operational UX oriented**, not accounting-screen-first
- **AI-ready extension points** for forecasting, copilots, anomaly detection, and bilingual assistants
- **integration-ready** for Turkish e-document flows, ERP sync, and Microsoft ecosystem services
- **cloud-friendly** structure that can evolve into a SaaS platform without a microservice rewrite on day one

## Project layout

```text
.
├── docs/
│   └── architecture.md
├── src/
│   ├── Api/
│   │   └── Iys.Api
│   ├── BuildingBlocks/
│   │   └── Iys.SharedKernel
│   └── Modules/
│       ├── Ai/
│       ├── Catalog/
│       ├── Inventory/
│       ├── Purchasing/
│       └── Reporting/
├── Directory.Build.props
├── Iys.sln
└── global.json
```

## MVP module boundaries

### Catalog
- items/raw materials/finished goods
- unit and tracking strategy placeholders
- reorder planning seed fields

### Inventory
- warehouses
- stock balances
- movement ledger and traceability
- lot/batch/serial-ready movement metadata

### Purchasing
- suppliers
- purchase order skeleton
- lead-time and currency awareness

### Reporting
- dashboard KPIs
- reporting snapshot contract
- future Power BI / analytics integration path

### AI
- capability registry
- future Azure OpenAI and ML workflow hooks
- extension points for copilots, replenishment suggestions, and operational anomaly detection

## Getting started

### Prerequisites

- .NET SDK `8.0.422` (pinned in `global.json`)

### Run locally

```bash
dotnet restore
dotnet build
dotnet run --project /home/runner/work/iys/iys/src/Api/Iys.Api/Iys.Api.csproj
```

Open Swagger at `http://localhost:5231/swagger` by default.

## Current API scaffold

The scaffold exposes starter endpoints for:

- `/api/catalog/items`
- `/api/inventory/warehouses`
- `/api/inventory/stock-balances`
- `/api/inventory/stock-movements`
- `/api/purchasing/suppliers`
- `/api/purchasing/purchase-orders`
- `/api/reporting/dashboard`
- `/api/ai/capabilities`

These are intentionally backed by in-memory services so the shape of the platform is ready before persistence and integrations are introduced.

## AI integration direction

Planned AI capabilities include:

- reorder quantity recommendations
- slow-moving and excess stock detection
- supplier delay risk scoring
- bilingual Turkish/English copilots for operational Q&A
- demand forecasting pipelines

The current scaffold includes contracts and placeholders so these can later be wired to Azure OpenAI, ML.NET, or external forecasting services without reworking module boundaries.

## Turkish market and integration TODOs

The scaffold intentionally leaves explicit extension points for:

- `TODO`: Turkish localization and bilingual UX defaults
- `TODO`: e-Fatura / e-İrsaliye / e-Defter integration
- `TODO`: Dynamics 365 Business Central and other ERP synchronization
- `TODO`: landed cost, FX, and EU-border workflow enhancements

## Roadmap

1. Add persistence with EF Core and PostgreSQL or SQL Server
2. Introduce authentication/authorization and tenant-aware company boundaries
3. Add goods receipt, stock count, and transfer commands
4. Add lot/serial traceability write flows and audit history
5. Introduce barcode/PWA warehouse workflows
6. Connect Turkish compliance and ERP integration adapters
7. Add production-lite, BOM, and forecasting modules
