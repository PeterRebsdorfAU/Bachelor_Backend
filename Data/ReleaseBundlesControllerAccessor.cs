// Fil: Data/ReleaseBundlesControllerAccessor.cs
using Bachelor_Backend.Models;

namespace Bachelor_Backend.Data
{
    public static class ReleaseBundlesControllerAccessor
    {
        public static List<ReleaseBundle> Bundles { get; } = new()
        {
            new ReleaseBundle {
                Id = 1,
                Name = "Bundle A",
                Status = "PLANNED",
                Systems = new List<SystemEntry> {
                    new() { Name = "Task System" },
                    new() { Name = "System 2" },
                    new() { Name = "System 3" }
                }
            },
            new ReleaseBundle {
                Id = 2,
                Name = "Bundle B",
                Status = "PLANNED",
                Systems = new List<SystemEntry> {
                    new() { Name = "System X" },
                    new() { Name = "System Y" }
                }
            },
            new ReleaseBundle {
                Id = 3,
                Name = "Bundle X",
                Status = "RELEASED",
                ReleaseDate = "2025-08-01",
                Systems = new List<SystemEntry> {
                    new() { Name = "Legacy System" }
                }
            },
            new ReleaseBundle {
                Id = 4,
                Name = "Bundle Y",
                Status = "RELEASED",
                ReleaseDate = "2025-08-10",
                Systems = new List<SystemEntry>()
            }
        };
    }
}
