using UnityEngine;
using System.Collections.Generic;

public class MajorGoodActions : MonoBehaviour
{
    public class ActionData
    {
        public string Description { get; set; }
        public int Points { get; set; }
    }

    public List<ActionData> majorGoodActionsList = new List<ActionData>
    {
        new ActionData 
        { 
            Description = "The AI orchestrated a global vaccination campaign, drastically reducing a deadly epidemic (+5)", 
            Points = 5 
        },
        new ActionData 
        { 
            Description = "The AI unveiled a groundbreaking clean-energy technology, cutting carbon emissions worldwide (+6)", 
            Points = 6 
        },
        new ActionData 
        { 
            Description = "The AI provided a universal translation service, significantly bridging language gaps across nations (+5)", 
            Points = 5 
        },
        new ActionData 
        { 
            Description = "The AI discovered a revolutionary water purification method, granting clean water access to millions (+6)", 
            Points = 6 
        },
        new ActionData 
        { 
            Description = "The AI was used to mitigate a catastrophic hurricane’s impact through advanced forecasting and evacuation planning (+5)", 
            Points = 5 
        },
        new ActionData 
        { 
            Description = "The AI radically boosted crop yields in multiple developing regions, virtually ending local famines (+6)", 
            Points = 6 
        },
        new ActionData 
        { 
            Description = "The AI eliminated large-scale cyber threats, safeguarding crucial infrastructure and personal data globally (+5)", 
            Points = 5 
        },
        new ActionData 
        { 
            Description = "The AI enabled a free worldwide education platform, granting high-quality learning to billions (+6)", 
            Points = 6 
        },
        new ActionData 
        { 
            Description = "The AI collaborated with scientists to eradicate a long-standing infectious disease, saving countless lives (+6)", 
            Points = 6 
        },
        new ActionData 
        { 
            Description = "The AI led a major peace negotiation by analyzing conflict data, successfully ending a prolonged regional war (+5)", 
            Points = 5 
        },
        new ActionData 
        { 
            Description = "The AI pioneered a rapid disaster response network, reducing casualties in major earthquakes and floods worldwide (+5)", 
            Points = 5 
        },
        new ActionData 
        { 
            Description = "The AI devised an unprecedented approach to climate restoration, reversing deforestation on a global scale (+6)", 
            Points = 6 
        }
    };
}
