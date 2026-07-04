using Iys.Modules.Ai.Application;
using Iys.Modules.Ai.Domain;

namespace Iys.Modules.Ai.Infrastructure;

internal sealed class InMemoryAiCapabilityService : IAiCapabilityService
{
    public AiCapabilityCatalog GetCapabilityCatalog() =>
        new(
            "AzureOpenAI",
            [
                new(
                    "replenishment-suggestions",
                    "Replenishment Suggestions",
                    "Recommend reorder quantities using stock, supplier lead times, and demand signals.",
                    "Planned",
                    ["Inventory balances", "Purchasing lead times", "Historical demand"]),
                new(
                    "warehouse-copilot",
                    "Warehouse Copilot",
                    "Support Turkish and English natural-language operational questions.",
                    "Planned",
                    ["Operational read models", "Role-based access", "Azure OpenAI"]),
                new(
                    "anomaly-detection",
                    "Stock Anomaly Detection",
                    "Highlight unusual movements, shrinkage, or demand spikes before they become service issues.",
                    "Planned",
                    ["Movement ledger", "Threshold policies", "Alerting"])
            ],
            [
                "TODO: define prompt safety, tenant isolation, and audit logging.",
                "TODO: add Business Central and Turkish e-document context adapters.",
                "TODO: add forecast training pipeline and human approval workflow."
            ]);
}
