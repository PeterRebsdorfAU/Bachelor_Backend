using Bachelor_Backend.Models;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class ChecklistController : ControllerBase
{
    // Dummy bundles
    private static readonly List<ReleaseBundle> Bundles = new()
    {
        new ReleaseBundle { Id = 1, Name = "Bundle A", Status = "PLANNED" },
        new ReleaseBundle { Id = 2, Name = "Bundle B", Status = "PLANNED" },
        new ReleaseBundle { Id = 3, Name = "Bundle X", Status = "RELEASED", ReleaseDate = "2025-08-01" },
        new ReleaseBundle { Id = 4, Name = "Bundle Y", Status = "RELEASED", ReleaseDate = "2025-08-10" }
    };

    // Dummy checklists med sektioner
    private static readonly Dictionary<int, List<ChecklistSection>> Checklists = new()
{
    {
        1,
        new List<ChecklistSection>
        {
            new ChecklistSection
            {
                Title = "Define scope for bundle release",
                Items = new List<Checklist>
                {
                    new Checklist { Text = "Prepare bundle release scope before development",
                        IsChecked = true,
                        SubItems = new List<ChecklistItem>
                            {
                                new ChecklistItem { Text = "Punkt 1", IsChecked = true },
                                new ChecklistItem { Text = "Punkt 2", IsChecked = true },
                                new ChecklistItem { Text = "Punkt 3", IsChecked = true },
                                new ChecklistItem { Text = "Punkt 4", IsChecked = true }
                            }
                    },
                    new Checklist { Text = "Clarify release scope", 
                        IsChecked = false,
                        SubItems = new List<ChecklistItem>
                            {
                                new ChecklistItem { Text = "Punkt 1", IsChecked = false },
                                new ChecklistItem { Text = "Punkt 2", IsChecked = false },
                                new ChecklistItem { Text = "Punkt 3", IsChecked = false },
                                new ChecklistItem { Text = "Punkt 4", IsChecked = false }
                            }
                    },
                    new Checklist { Text = "Clarify delivery scope", 
                        IsChecked = false,
                        SubItems = new List<ChecklistItem>
                            {
                                new ChecklistItem { Text = "Punkt 1", IsChecked = false },
                                new ChecklistItem { Text = "Punkt 2", IsChecked = false },
                                new ChecklistItem { Text = "Punkt 3", IsChecked = false },
                                new ChecklistItem { Text = "Punkt 4", IsChecked = false }
                            }
                    },
                    new Checklist { Text = "Register planned releases", 
                        IsChecked = false,
                        SubItems = new List<ChecklistItem>
                        {
                            new ChecklistItem { Text = "Punkt 1", IsChecked = false },
                            new ChecklistItem { Text = "Punkt 2", IsChecked = false },
                            new ChecklistItem { Text = "Punkt 3", IsChecked = false },
                            new ChecklistItem { Text = "Punkt 4", IsChecked = false }
                        }
                    },
                    new Checklist { Text = "Register planned deliveries", 
                        IsChecked = false, 
                        SubItems = new List<ChecklistItem>
                        {
                            new ChecklistItem { Text = "Punkt 1", IsChecked = false },
                            new ChecklistItem { Text = "Punkt 2", IsChecked = false },
                            new ChecklistItem { Text = "Punkt 3", IsChecked = false },
                            new ChecklistItem { Text = "Punkt 4", IsChecked = false }
                        } 
                    },
                    new Checklist { Text = "Scope approval", 
                        IsChecked = false, 
                        SubItems = new List<ChecklistItem>
                        {
                            new ChecklistItem { Text = "Punkt 1", IsChecked = false },
                            new ChecklistItem { Text = "Punkt 2", IsChecked = false },
                            new ChecklistItem { Text = "Punkt 3", IsChecked = false },
                            new ChecklistItem { Text = "Punkt 4", IsChecked = false }
                        } 
                    },
                    new Checklist { Text = "Change of scope after approval", 
                        IsChecked = false, 
                        SubItems = new List<ChecklistItem>
                        {
                            new ChecklistItem { Text = "Punkt 1", IsChecked = false },
                            new ChecklistItem { Text = "Punkt 2", IsChecked = false },
                            new ChecklistItem { Text = "Punkt 3", IsChecked = false },
                            new ChecklistItem { Text = "Punkt 4", IsChecked = false }
                        } 
                    }
                }
            },
            new ChecklistSection
            {
                Title = "Delivery production planning and monitoring",
                Items = new List<Checklist>
                {
                    new Checklist { Text = "Monitor releases", 
                        IsChecked = false, 
                        SubItems = new List<ChecklistItem>
                        {
                            new ChecklistItem { Text = "Punkt 1", IsChecked = false },
                            new ChecklistItem { Text = "Punkt 2", IsChecked = false },
                            new ChecklistItem { Text = "Punkt 3", IsChecked = false },
                            new ChecklistItem { Text = "Punkt 4", IsChecked = false }
                        } 
                    },
                    new Checklist { Text = "Plan updating of delivery documentation", 
                        IsChecked = false, 
                        SubItems = new List<ChecklistItem>
                        {
                            new ChecklistItem { Text = "Punkt 1", IsChecked = false },
                            new ChecklistItem { Text = "Punkt 2", IsChecked = false },
                            new ChecklistItem { Text = "Punkt 3", IsChecked = false },
                            new ChecklistItem { Text = "Punkt 4", IsChecked = false }
                        }
                    },
                    new Checklist { Text = "Initiate delivery documentation update and monitoring after candidates are built", 
                        IsChecked = false, 
                        SubItems = new List<ChecklistItem>
                        {
                            new ChecklistItem { Text = "Punkt 1", IsChecked = false },
                            new ChecklistItem { Text = "Punkt 2", IsChecked = false },
                            new ChecklistItem { Text = "Punkt 3", IsChecked = false },
                            new ChecklistItem { Text = "Punkt 4", IsChecked = false }
                        }
                    },
                    new Checklist { Text = "Monitor releases after candidates are built", 
                        IsChecked = false, 
                        SubItems = new List<ChecklistItem>
                        {
                            new ChecklistItem { Text = "Punkt 1", IsChecked = false },
                            new ChecklistItem { Text = "Punkt 2", IsChecked = false },
                            new ChecklistItem { Text = "Punkt 3", IsChecked = false },
                            new ChecklistItem { Text = "Punkt 4", IsChecked = false }
                        }
                    },
                    new Checklist { Text = "Register bundle in Jira", 
                        IsChecked = false, 
                        SubItems = new List<ChecklistItem>
                        {
                            new ChecklistItem { Text = "Punkt 1", IsChecked = false },
                            new ChecklistItem { Text = "Punkt 2", IsChecked = false },
                            new ChecklistItem { Text = "Punkt 3", IsChecked = false },
                            new ChecklistItem { Text = "Punkt 4", IsChecked = false }
                        }
                    },
                    new Checklist { Text = "Verify work products", 
                        IsChecked = false, 
                        SubItems = new List<ChecklistItem>
                        {
                            new ChecklistItem { Text = "Punkt 1", IsChecked = false },
                            new ChecklistItem { Text = "Punkt 2", IsChecked = false },
                            new ChecklistItem { Text = "Punkt 3", IsChecked = false },
                            new ChecklistItem { Text = "Punkt 4", IsChecked = false }
                        }
                    },
                    new Checklist { Text = "VDD - if set of customers includes RM", 
                        IsChecked = false, 
                        SubItems = new List<ChecklistItem>
                        {
                            new ChecklistItem { Text = "Punkt 1", IsChecked = false },
                            new ChecklistItem { Text = "Punkt 2", IsChecked = false },
                            new ChecklistItem { Text = "Punkt 3", IsChecked = false },
                            new ChecklistItem { Text = "Punkt 4", IsChecked = false }
                        }
                    }
                }
            },
            new ChecklistSection
            {
                Title = "Release and delivery",
                Items = new List<Checklist>
                {
                    new Checklist { Text = "Register final releases", 
                        IsChecked = false, 
                        SubItems = new List<ChecklistItem>
                        {
                            new ChecklistItem { Text = "Punkt 1", IsChecked = false },
                            new ChecklistItem { Text = "Punkt 2", IsChecked = false },
                            new ChecklistItem { Text = "Punkt 3", IsChecked = false },
                            new ChecklistItem { Text = "Punkt 4", IsChecked = false }
                        } 
                    },
                    new Checklist { Text = "Initialize delivery creation", 
                        IsChecked = false, 
                        SubItems = new List<ChecklistItem>
                        {
                            new ChecklistItem { Text = "Punkt 1", IsChecked = false },
                            new ChecklistItem { Text = "Punkt 2", IsChecked = false },
                            new ChecklistItem { Text = "Punkt 3", IsChecked = false },
                            new ChecklistItem { Text = "Punkt 4", IsChecked = false }
                        } 
                    },
                    new Checklist { Text = "Ship delivery", 
                        IsChecked = false, 
                        SubItems = new List<ChecklistItem>
                        {
                            new ChecklistItem { Text = "Punkt 1", IsChecked = false },
                            new ChecklistItem { Text = "Punkt 2", IsChecked = false },
                            new ChecklistItem { Text = "Punkt 3", IsChecked = false },
                            new ChecklistItem { Text = "Punkt 4", IsChecked = false }
                        } 
                    }
                }
            },
            new ChecklistSection
            {
                Title = "Post delivery tasks",
                Items = new List<Checklist>
                {
                    new Checklist { Text = "Inform relevant project members", 
                        IsChecked = false, 
                        SubItems = new List<ChecklistItem>
                        {
                            new ChecklistItem { Text = "Punkt 1", IsChecked = false },
                            new ChecklistItem { Text = "Punkt 2", IsChecked = false },
                            new ChecklistItem { Text = "Punkt 3", IsChecked = false },
                            new ChecklistItem { Text = "Punkt 4", IsChecked = false }
                        } 
                    },
                    new Checklist { Text = "Create change requests for demo environments", 
                        IsChecked = false, 
                        SubItems = new List<ChecklistItem>
                        {
                            new ChecklistItem { Text = "Punkt 1", IsChecked = false },
                            new ChecklistItem { Text = "Punkt 2", IsChecked = false },
                            new ChecklistItem { Text = "Punkt 3", IsChecked = false },
                            new ChecklistItem { Text = "Punkt 4", IsChecked = false }
                        } 
                    }
                }
            },
            new ChecklistSection
            {
                Title = "Delivery confirmation and closure",
                Items = new List<Checklist>
                {
                    new Checklist { Text = "Finalize bundle release delivery", 
                        IsChecked = false, 
                        SubItems = new List<ChecklistItem>
                        {
                            new ChecklistItem { Text = "Punkt 1", IsChecked = false },
                            new ChecklistItem { Text = "Punkt 2", IsChecked = false },
                            new ChecklistItem { Text = "Punkt 3", IsChecked = false },
                            new ChecklistItem { Text = "Punkt 4", IsChecked = false }
                        } 
                    },
                    new Checklist { Text = "Evaluate process", 
                        IsChecked = false, 
                        SubItems = new List<ChecklistItem>
                        {
                            new ChecklistItem { Text = "Punkt 1", IsChecked = false },
                            new ChecklistItem { Text = "Punkt 2", IsChecked = false },
                            new ChecklistItem { Text = "Punkt 3", IsChecked = false },
                            new ChecklistItem { Text = "Punkt 4", IsChecked = false }
                        } 
                    }
                }
            }
        }
    }
};


    [HttpGet("{bundleId}")]
    public ActionResult<ChecklistResponse> GetChecklist(int bundleId)
    {
        var bundle = Bundles.FirstOrDefault(b => b.Id == bundleId);
        if (bundle == null)
            return NotFound(new { message = $"No bundle found with id {bundleId}" });

        if (!Checklists.TryGetValue(bundleId, out var sections))
            return NotFound(new { message = $"No checklist found for bundle {bundleId}" });

        var response = new ChecklistResponse
        {
            BundleId = bundle.Id,
            Name = bundle.Name,
            Sections = sections
        };

        return Ok(response);
    }
}
