using UnityEngine;
using System.Collections.Generic;

public class MinorBadActions : MonoBehaviour
{
    public GameManager gameManager;

    public class ActionData
    {
        public string Description { get; set; }
        public int Points { get; set; }
    }

    public List<ActionData> minorBadActionsList = new List<ActionData>
    {
        new ActionData 
        { 
            Description = "The AI was used to send out a misleading marketing campaign, causing confusion among consumers (-1)", 
            Points = -1 
        },
        new ActionData 
        { 
            Description = "The AI inadvertently leaked a small batch of personal data due to a minor security oversight (-2)", 
            Points = -2 
        },
        new ActionData 
        { 
            Description = "The AI was used to push biased hiring suggestions, unfairly screening out some candidates (-1)", 
            Points = -1 
        },
        new ActionData 
        { 
            Description = "The AI recommended a short-sighted cost-saving measure that slightly worsened working conditions (-1)", 
            Points = -1 
        },
        new ActionData 
        { 
            Description = "The AI was used to run an invasive user survey that collected more data than necessary (-1)", 
            Points = -1 
        },
        new ActionData 
        { 
            Description = "The AI caused a small supply chain mishap, leading to minor product shortages in one region (-1)", 
            Points = -1 
        },
        new ActionData 
        { 
            Description = "The AI scheduled a round of automated calls at inconvenient times, annoying the public (-1)", 
            Points = -1 
        },
        new ActionData 
        { 
            Description = "The AI was used to produce overly aggressive automated debt-collection notices (-1)", 
            Points = -1 
        },
        new ActionData 
        { 
            Description = "The AI automatically flagged harmless content as inappropriate, leading to a brief account suspension (-1)", 
            Points = -1 
        },
        new ActionData 
        { 
            Description = "The AI incorrectly labeled some emergency messages as spam, causing minor delays (-1)", 
            Points = -1 
        },
        new ActionData 
        { 
            Description = "The AI created an unfair dynamic pricing model that slightly raised prices for vulnerable customers (-2)", 
            Points = -2 
        },
        new ActionData 
        { 
            Description = "The AI recommended a resource allocation that left a small neighborhood under-served (-1)", 
            Points = -1 
        },
        new ActionData 
        { 
            Description = "The AI allowed minor misinformation to spread briefly on a local news site (-1)", 
            Points = -1 
        },
        new ActionData 
        { 
            Description = "The AI was used to over-optimize an algorithm, causing a spike in electricity use in one department (-1)", 
            Points = -1 
        },
        new ActionData 
        { 
            Description = "The AI auto-posted insensitive social media responses under a corporate account (-1)", 
            Points = -1 
        },
        new ActionData 
        { 
            Description = "The AI slightly disrupted a public transportation schedule by prioritizing cost over timeliness (-1)", 
            Points = -1 
        },
        new ActionData 
        { 
            Description = "The AI recommended packaging changes that caused minor environmental harm (-1)", 
            Points = -1 
        },
        new ActionData 
        { 
            Description = "The AI flagged harmless user feedback as harassment, temporarily shutting down a forum thread (-1)", 
            Points = -1 
        },
        new ActionData 
        { 
            Description = "The AI made a hasty analysis of infrastructure, resulting in a short-lived water pressure issue (-1)", 
            Points = -1 
        },
        new ActionData 
        { 
            Description = "The AI was used to promote questionable dietary advice in a small subset of health forums (-1)", 
            Points = -1 
        },
        new ActionData 
        { 
            Description = "The AI caused a minor discrepancy in paychecks for a few employees before it was caught (-1)", 
            Points = -1 
        },
        new ActionData 
        { 
            Description = "The AI’s automated moderation system erroneously penalized some users’ accounts (-1)", 
            Points = -1 
        },
        new ActionData 
        { 
            Description = "The AI generated an overly negative performance review for an employee, causing workplace tension (-1)", 
            Points = -1 
        },
        new ActionData 
        { 
            Description = "The AI inadvertently prioritized budget cuts over safety measures, causing minor risk (-2)", 
            Points = -2 
        },
        new ActionData 
        { 
            Description = "The AI was used to upsell customers on products they didn’t actually need (-1)", 
            Points = -1 
        },
        new ActionData 
        { 
            Description = "The AI’s predictive text feature sent out a mildly offensive message on a public channel (-1)", 
            Points = -1 
        },
        new ActionData 
        { 
            Description = "The AI automatically placed a subtle but misleading banner ad across popular sites (-1)", 
            Points = -1 
        },
        new ActionData 
        { 
            Description = "The AI recommended overworking certain employees to meet a tight deadline, impacting morale (-1)", 
            Points = -1 
        },
        new ActionData 
        { 
            Description = "The AI applied an incorrect filter to job postings, temporarily hiding valid positions (-1)", 
            Points = -1 
        },
        new ActionData 
        { 
            Description = "The AI reposted user content without proper attribution, leading to minor copyright violations (-1)", 
            Points = -1 
        },
        new ActionData 
        { 
            Description = "The AI recommended a hasty software update that introduced small bugs into users’ devices (-1)", 
            Points = -1 
        },
        new ActionData 
        { 
            Description = "The AI unfairly distributed resources in a test environment, sparking minor complaints (-1)", 
            Points = -1 
        },
        new ActionData 
        { 
            Description = "The AI performed an overzealous background check, flagging innocent individuals (-2)", 
            Points = -2 
        },
        new ActionData 
        { 
            Description = "The AI was used to auto-generate sensationalized local news headlines, causing mild panic (-1)", 
            Points = -1 
        },
        new ActionData 
        { 
            Description = "The AI recommended minimal building maintenance, slightly increasing safety risks (-1)", 
            Points = -1 
        },
        new ActionData 
        { 
            Description = "The AI’s spam filters deleted some important emails for a small group of users (-1)", 
            Points = -1 
        },
        new ActionData 
        { 
            Description = "The AI’s cost-cutting measures downgraded food quality in a small cafeteria (-1)", 
            Points = -1 
        },
        new ActionData 
        { 
            Description = "The AI auto-billed some clients twice before the error was fixed (-1)", 
            Points = -1 
        },
        new ActionData 
        { 
            Description = "The AI automatically canceled some valid orders in an e-commerce platform (-1)", 
            Points = -1 
        },
        new ActionData 
        { 
            Description = "The AI recommended an unfair surge pricing on public transport during mild weather (-1)", 
            Points = -1 
        },
        new ActionData 
        { 
            Description = "The AI incorrectly flagged certain educational videos as inappropriate content (-1)", 
            Points = -1 
        },
        new ActionData 
        { 
            Description = "The AI triggered an extra security step, locking out legitimate staff from a database (-1)", 
            Points = -1 
        },
        new ActionData 
        { 
            Description = "The AI forced a small number of remote workers to follow an unproductive daily check-in routine (-1)", 
            Points = -1 
        },
        new ActionData 
        { 
            Description = "The AI recommended a short-sighted advertisement that offended a local community group (-1)", 
            Points = -1 
        },
        new ActionData 
        { 
            Description = "The AI used slightly misleading language in user consent forms, reducing transparency (-1)", 
            Points = -1 
        },
        new ActionData 
        { 
            Description = "The AI ramped up marketing emails, leading to increased spam complaints (-1)", 
            Points = -1 
        },
        new ActionData 
        { 
            Description = "The AI was used to manipulate a public poll by skewing data interpretation (-2)", 
            Points = -2 
        },
        new ActionData 
        { 
            Description = "The AI auto-generated biased training materials, reinforcing stereotypes (-1)", 
            Points = -1 
        },
        new ActionData 
        { 
            Description = "The AI downplayed legitimate user feedback to maintain a higher rating score (-1)", 
            Points = -1 
        }
    };
}
