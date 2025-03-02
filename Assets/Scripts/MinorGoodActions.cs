using UnityEngine;
using System.Collections.Generic;

public class MinorGoodActions : MonoBehaviour
{
    public class ActionData
    {
        public string Description { get; set; }
        public int Points { get; set; }
    }

    public List<ActionData> minorGoodActionsList = new List<ActionData>
    {
        new ActionData 
        { 
            Description = "The AI was used to optimize local traffic signals to reduce commute times by a few minutes (+1)", 
            Points = 1 
        },
        new ActionData 
        { 
            Description = "The AI was used to autocorrect an electrical grid glitch in one neighborhood, preventing a brief blackout (+1)", 
            Points = 1 
        },
        new ActionData 
        { 
            Description = "The AI was used to identify a small fraud ring, saving a local business from minor losses (+1)", 
            Points = 1 
        },
        new ActionData 
        { 
            Description = "The AI was used to find missing pets by cross-referencing shelter data (+1)", 
            Points = 1 
        },
        new ActionData 
        { 
            Description = "The AI was used to recommend cost-effective packaging for a local manufacturer, cutting waste (+1)", 
            Points = 1 
        },
        new ActionData 
        { 
            Description = "The AI was used to add accessibility features on a public website, improving usability for visually impaired users (+1)", 
            Points = 1 
        },
        new ActionData 
        { 
            Description = "The AI was used to suggest micro-loans to small businesses in an underserved area (+1)", 
            Points = 1 
        },
        new ActionData 
        { 
            Description = "The AI was used to reconfigure a city water treatment process, slightly reducing chemical usage (+2)", 
            Points = 2 
        },
        new ActionData 
        { 
            Description = "The AI was used to automate appointment scheduling for a rural clinic (+1)", 
            Points = 1 
        },
        new ActionData 
        { 
            Description = "The AI was used to alert local farmers of an impending pest issue (+1)", 
            Points = 1 
        },
        new ActionData 
        { 
            Description = "The AI was used to improve a medical triage system, cutting hospital wait times a bit (+1)", 
            Points = 1 
        },
        new ActionData 
        { 
            Description = "The AI was used to run a 'green tips' PSA on social media, leading to minor energy savings (+1)", 
            Points = 1 
        },
        new ActionData 
        { 
            Description = "The AI was used to tweak online search results to highlight local nonprofits and charities (+1)", 
            Points = 1 
        },
        new ActionData 
        { 
            Description = "The AI was used to improve route optimization for delivery drivers, reducing fuel consumption (+1)", 
            Points = 1 
        },
        new ActionData 
        { 
            Description = "The AI was used to block a minor malware attempt that would have cost users time or money (+1)", 
            Points = 1 
        },
        new ActionData 
        { 
            Description = "The AI was used to analyze library usage data, expanding popular e-book collections slightly (+1)", 
            Points = 1 
        },
        new ActionData 
        { 
            Description = "The AI was used to pinpoint small budget savings in local government so funds could be redirected to community events (+1)", 
            Points = 1 
        },
        new ActionData 
        { 
            Description = "The AI was used to give out free localized weather alerts via text messaging (+1)", 
            Points = 1 
        },
        new ActionData 
        { 
            Description = "The AI was used to advise on a mild diet improvement for a hospital cafeteria, reducing sugar usage (+1)", 
            Points = 1 
        },
        new ActionData 
        { 
            Description = "The AI was used to schedule volunteer shifts for a soup kitchen more efficiently (+1)", 
            Points = 1 
        },
        new ActionData 
        { 
            Description = "The AI was used to highlight scholarship opportunities for low-income students (+1)", 
            Points = 1 
        },
        new ActionData 
        { 
            Description = "The AI was used to reroute emergency vehicles around mild traffic congestion (+2)", 
            Points = 2 
        },
        new ActionData 
        { 
            Description = "The AI was used to automate an overdue notice system for a school lunch program, preventing missed meals (+1)", 
            Points = 1 
        },
        new ActionData 
        { 
            Description = "The AI was used to coordinate social media fundraisers for small local causes (+1)", 
            Points = 1 
        },
        new ActionData 
        { 
            Description = "The AI was used to advise a nonprofit on the best times for donation drives (+1)", 
            Points = 1 
        },
        new ActionData 
        { 
            Description = "The AI was used to suggest small software updates that reduced a company’s server energy consumption slightly (+1)", 
            Points = 1 
        },
        new ActionData 
        { 
            Description = "The AI was used to identify a simpler recycling procedure for a small municipality (+1)", 
            Points = 1 
        },
        new ActionData 
        { 
            Description = "The AI was used to organize a 'digital day' in a small town to teach basic coding to kids (+1)", 
            Points = 1 
        },
        new ActionData 
        { 
            Description = "The AI was used to automate a small tutoring hotline for math or language help (+1)", 
            Points = 1 
        },
        new ActionData 
        { 
            Description = "The AI was used to enhance ride-sharing routes so more people could be picked up in fewer miles (+1)", 
            Points = 1 
        },
        new ActionData 
        { 
            Description = "The AI was used to flag a minor health hazard in an office building’s ventilation (+1)", 
            Points = 1 
        },
        new ActionData 
        { 
            Description = "The AI was used to create a simple smartphone app to coordinate dog-walking volunteers for the elderly (+1)", 
            Points = 1 
        },
        new ActionData 
        { 
            Description = "The AI was used to run a matching algorithm for local job seekers and small businesses (+1)", 
            Points = 1 
        },
        new ActionData 
        { 
            Description = "The AI was used to implement a quick mental health survey at a small university, providing optional resources (+1)", 
            Points = 1 
        },
        new ActionData 
        { 
            Description = "The AI was used to suggest local farmers’ markets donate produce to a homeless shelter (+1)", 
            Points = 1 
        },
        new ActionData 
        { 
            Description = "The AI was used to notify city officials of a minor structural crack in a public bridge so it could be fixed early (+1)", 
            Points = 1 
        },
        new ActionData 
        { 
            Description = "The AI was used to refine local bus route schedules, shaving minutes off passenger wait times (+1)", 
            Points = 1 
        },
        new ActionData 
        { 
            Description = "The AI was used to compress city government data to free up more server space, saving costs (+1)", 
            Points = 1 
        },
        new ActionData 
        { 
            Description = "The AI was used to create a short social media campaign reminding people to get flu shots (+1)", 
            Points = 1 
        },
        new ActionData 
        { 
            Description = "The AI was used to offer a micro-scholarship to a few underprivileged students (+2)", 
            Points = 2 
        },
        new ActionData 
        { 
            Description = "The AI was used to auto-translate local health brochures for new immigrants (+1)", 
            Points = 1 
        },
        new ActionData 
        { 
            Description = "The AI was used to analyze a minor teacher-student ratio mismatch in local schools, suggesting better distribution (+1)", 
            Points = 1 
        },
        new ActionData 
        { 
            Description = "The AI was used to assist a small volunteer firefighting unit with AI-based route planning (+1)", 
            Points = 1 
        },
        new ActionData 
        { 
            Description = "The AI was used to coordinate a digital lost-and-found system at major local event venues (+1)", 
            Points = 1 
        },
        new ActionData 
        { 
            Description = "The AI was used to predict mild local flooding in time for supplies to be moved to higher ground (+1)", 
            Points = 1 
        },
        new ActionData 
        { 
            Description = "The AI was used to share anonymized health data with a small research group, speeding up a minor study (+1)", 
            Points = 1 
        },
        new ActionData 
        { 
            Description = "The AI was used to provide a free 'speech to text' widget for local government websites (+1)", 
            Points = 1 
        },
        new ActionData 
        { 
            Description = "The AI was used to warn about a slight mold risk in a city building after heavy rains (+1)", 
            Points = 1 
        },
        new ActionData 
        { 
            Description = "The AI was used to recommend a shift to energy-saving bulbs in a local office building (+1)", 
            Points = 1 
        },
        new ActionData 
        { 
            Description = "The AI was used to email simple data-based tips to residents for saving on their water bills (+1)", 
            Points = 1 
        }
    };
}
