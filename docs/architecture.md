# IYS architecture notes

## Architectural direction

IYS starts as a **modular monolith** to balance delivery speed, maintainability, and future SaaS evolution.

This choice is intentional:

- simpler than early microservices for a new product
- clearer module boundaries than a single web project
- ready for staged extraction of AI, integration, or reporting workloads later
- easy to host on Azure App Service, containers, or AKS when needed

## Module structure

Each module is isolated in its own project and currently contains:

- starter domain models
- service contracts
- in-memory bootstrap implementations
- API registration/mapping extensions

### Catalog

Owns master data for items and product definitions.

Future candidates:
- units of measure
- category hierarchy
- barcode definitions
- item variants
- BOM/product family modeling

### Inventory

Owns warehouses, balances, and movement-level traceability.

Future candidates:
- stock counts
- inter-warehouse transfers
- reservations
- lot/serial dimensions
- quality hold and quarantine flows

### Purchasing

Owns supplier-facing procurement workflows.

Future candidates:
- requisitions
- approval routing
- receipt matching
- landed cost capture
- vendor performance scoring

### Reporting

Owns dashboard snapshots and KPI publication.

Future candidates:
- company and warehouse scorecards
- operational drill-down reports
- Power BI embedding
- scheduled report delivery

### AI

Owns AI capability discovery and integration contracts.

Future candidates:
- Azure OpenAI assistants
- forecasting pipelines
- replenishment recommendation engines
- anomaly detection services
- conversational operational analytics

## API style

The API uses minimal APIs for the initial scaffold because they are fast to evolve while the domain surface is still forming.

As the platform matures, modules can grow into:

- command/query handlers
- validation pipelines
- persistence adapters
- integration event publishing

without changing the top-level repository shape.

## Shared kernel

`Iys.SharedKernel` currently holds simple cross-cutting concepts only.

This should remain intentionally small. Shared code should only live there when it is genuinely common and stable; otherwise it should stay inside the owning module.

## Integration and localization direction

Planned integration lanes:

- Microsoft Dynamics 365 Business Central
- Turkish e-document providers
- barcode scanners and mobile/PWA clients
- BI/reporting tools
- external AI services

Planned localization lanes:

- Turkish-first terminology support
- bilingual Turkish/English UI and assistant prompts
- TRY/EUR and FX-aware transaction modeling
- Turkish tax and document workflow extensions

## Repository growth path

Short term:
- keep business logic inside module projects
- use in-memory services only as scaffolding
- add EF Core persistence per module

Medium term:
- add auth, tenants, companies, and operational transactions
- introduce background jobs and integration workers
- add production planning/consumption flows

Long term:
- extract high-throughput or AI-heavy workloads only when justified
- keep the operational platform coherent for SMEs and mid-market manufacturers
