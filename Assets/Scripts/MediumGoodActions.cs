using UnityEngine;
using System.Collections.Generic;

public class MediumGoodActions : MonoBehaviour
{
    public class ActionData
    {
        public string Description { get; set; }
        public int Points { get; set; }
    }

    public List<ActionData> mediumGoodActionsList = new List<ActionData>
    {
        new ActionData 
        { 
            Description = "The AI was used to detect an early-stage pandemic threat in one region, prompting quick local containment (+3)", 
            Points = 3 
        },
        new ActionData 
        { 
            Description = "The AI was used to facilitate a regional green-energy initiative, significantly reducing emissions over a season (+3)", 
            Points = 3 
        },
        new ActionData 
        { 
            Description = "The AI developed an affordable online education program, boosting graduation rates in a local district (+3)", 
            Points = 3 
        },
        new ActionData 
        { 
            Description = "The AI discovered a new approach to water filtration for a small city, improving water quality for thousands of residents (+3)", 
            Points = 3 
        },
        new ActionData 
        { 
            Description = "The AI was used to streamline hospital logistics, decreasing ER wait times noticeably (+3)", 
            Points = 3 
        },
        new ActionData 
        { 
            Description = "The AI helped coordinate a multi-city food drive, reducing food waste and feeding more families in need (+3)", 
            Points = 3 
        },
        new ActionData 
        { 
            Description = "The AI provided a new insight into a regional transit plan, leading to more efficient bus and rail scheduling (+3)", 
            Points = 3 
        },
        new ActionData 
        { 
            Description = "The AI enabled a major reduction in harmful industrial byproducts by optimizing factory processes (+4)", 
            Points = 4 
        },
        new ActionData 
        { 
            Description = "The AI expedited a crucial vaccine distribution effort in a developing area, increasing immunization rates (+3)", 
            Points = 3 
        },
        new ActionData 
        { 
            Description = "The AI was used to optimize a community health program, reducing chronic disease complications for residents (+3)", 
            Points = 3 
        },
        new ActionData 
        { 
            Description = "The AI identified a promising new drug formulation for a rare disease, speeding up early research steps (+4)", 
            Points = 4 
        },
        new ActionData 
        { 
            Description = "The AI analyzed local economies to recommend targeted grants, resulting in new job opportunities (+3)", 
            Points = 3 
        },
        new ActionData 
        { 
            Description = "The AI orchestrated a regional recycling and composting overhaul, raising environmental compliance rates significantly (+3)", 
            Points = 3 
        },
        new ActionData 
        { 
            Description = "The AI helped coordinate a relief response to a moderate natural disaster, reducing recovery time for affected communities (+3)", 
            Points = 3 
        },
        new ActionData 
        { 
            Description = "The AI was used to significantly cut energy consumption in local government buildings, lowering costs for taxpayers (+3)", 
            Points = 3 
        },
        new ActionData 
        { 
            Description = "The AI offered breakthrough insights on crop rotation, leading to substantial yield increases for several farms (+4)", 
            Points = 4 
        },
        new ActionData 
        { 
            Description = "The AI compiled better workforce training plans, improving regional employment readiness (+3)", 
            Points = 3 
        },
        new ActionData 
        { 
            Description = "The AI was used to identify early signs of structural issues in multiple public buildings, averting major repair costs (+3)", 
            Points = 3 
        },
        new ActionData 
        { 
            Description = "The AI optimized shipping routes across multiple companies, reducing freight emissions and delivery times (+3)", 
            Points = 3 
        },
        new ActionData 
        { 
            Description = "The AI built a targeted tutoring curriculum that helped thousands of students raise their test scores (+4)", 
            Points = 4 
        },
        new ActionData 
        { 
            Description = "The AI helped track and mitigate pollution in a major river, making water safer for surrounding communities (+3)", 
            Points = 3 
        },
        new ActionData 
        { 
            Description = "The AI streamlined a local social services network, connecting vulnerable citizens to resources faster (+3)", 
            Points = 3 
        },
        new ActionData 
        { 
            Description = "The AI was used to coordinate multiple nonprofits’ fundraising drives, boosting total donations significantly (+3)", 
            Points = 3 
        },
        new ActionData 
        { 
            Description = "The AI provided real-time supply tracking in regional medical centers, preventing critical shortages (+3)", 
            Points = 3 
        },
        new ActionData 
        { 
            Description = "The AI identified a novel building insulation strategy that reduced heating costs for an entire neighborhood (+4)", 
            Points = 4 
        }
    };

}
