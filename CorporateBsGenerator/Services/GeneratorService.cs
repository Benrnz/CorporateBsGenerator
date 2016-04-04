using System;
using System.Collections.Generic;
using System.Linq;

namespace CorporateBsGenerator.Services
{
    public class GeneratorService
    {
        private static Random RandomGenerator;
        private static List<string> Adverbs = new List<string> {
            "appropriately", "assertively", "authoritatively", "collaboratively", "compellingly", "competently", "completely",
            "continually", "conveniently", "credibly", "distinctively", "dramatically", "dynamically", "efficiently",
            "energistically", "enthusiastically", "globally", "holisticly", "interactively", "intrinsically", "monotonectally",
            "objectively", "phosfluorescently", "proactively", "professionally", "progressively", "quickly", "rapidiously",
            "seamlessly", "synergistically", "uniquely", "fungibly"
            };

        private static List<string> Verbs = new List<string> {
            "actualise", "administrate", "aggregate", "architect", "benchmark", "brand", "build", "communicate", "conceptualise",
            "coordinate", "create", "cultivate", "customise", "deliver", "deploy", "develop", "disintermediate", "disseminate",
            "drive", "embrace", "e-enable", "empower", "enable", "engage", "engineer", "enhance", "envisioneer", "evisculate",
            "evolve", "expedite", "exploit", "extend", "fabricate", "facilitate", "fashion", "formulate", "foster", "generate",
            "grow", "harness", "impact", "implement", "incentivise", "incubate", "initiate", "innovate", "integrate", "iterate",
            "leverage existing", "leverage other\"s", "maintain", "matrix", "maximise", "mesh", "monetise", "morph", "myocardinate",
            "negotiate", "network", "optimise", "orchestrate", "parallel task", "plagiarise", "pontificate", "predominate",
            "procrastinate", "productivate", "productise", "promote", "provide access to", "pursue", "recaptiualise",
            "reconceptualise", "redefine", "re-engineer", "reintermediate", "reinvent", "repurpose", "restore", "revolutionise",
            "scale", "seize", "simplify", "strategise", "streamline", "supply", "syndicate", "synergise", "synthesize", "target",
            "transform", "transition", "underwhelm", "unleash", "utilise", "visualise", "whiteboard", "cloudify", "right-shore"
            };

        private static List<string> Adjectives = new List<string> {
            "24/7", "24/365", "accurate", "adaptive", "alternative", "an expanded array of", "B2B", "B2C", "backend",
            "backward-compatible", "best-of-breed", "bleeding-edge", "bricks-and-clicks", "business", "clicks-and-mortar",
            "client-based", "client-centered", "client-centric", "client-focused", "collaborative", "compelling", "competitive",
            "cooperative", "corporate", "cost effective", "covalent", "cross functional", "cross-media", "cross-platform",
            "cross-unit", "customer directed", "customised", "cutting-edge", "distinctive", "distributed", "diverse", "dynamic",
            "e-business", "economically sound", "effective", "efficient", "emerging", "empowered", "enabled", "end-to-end",
            "enterprise", "enterprise-wide", "equity invested", "error-free", "ethical", "excellent", "exceptional", "extensible",
            "extensive", "flexible", "focused", "frictionless", "front-end", "fully researched", "fully tested", "functional",
            "functionalized", "future-proof", "global", "go forward", "goal-oriented", "granular", "high standards in",
            "high-payoff", "high-quality", "highly efficient", "holistic", "impactful", "inexpensive", "innovative",
            "installed base", "integrated", "interactive", "interdependent", "intermandated", "interoperable", "intuitive",
            "just in time", "leading-edge", "leveraged", "long-term high-impact", "low-risk high-yield", "magnetic",
            "maintainable", "market positioning", "market-driven", "mission-critical", "multidisciplinary", "multifunctional",
            "multimedia based", "next-generation", "one-to-one", "open-source", "optimal", "orthogonal", "out-of-the-box",
            "pandemic", "parallel", "performance based", "plug-and-play", "premier", "premium", "principle-centered", "proactive",
            "process-centric", "professional", "progressive", "prospective", "quality", "real-time", "reliable", "resource-sucking",
            "resource-maximising", "resource-leveling", "revolutionary", "robust", "scalable", "seamless", "stand-alone",
            "standardised", "standards compliant", "state of the art", "sticky", "strategic", "superior", "sustainable",
            "synergistic", "tactical", "team building", "team driven", "technically sound", "timely", "top-line", "transparent",
            "turnkey", "ubiquitous", "unique", "user-centric", "user friendly", "value-added", "vertical", "viral", "virtual",
            "visionary", "web-enabled", "wireless", "world-class", "worldwide", "fungible", "cloud-ready", "elastic", "hyper-scale",
            "on-demand", "cloud-based", "cloud-centric", "cloudified", "aggresive", "disruptive", "hyper-cadence", "loosely coupled",
            "dilated", "quantum"

            };

        private static List<string> Nouns = new List<string> {
            "artificial intelligence", "alignments", "real time data", "architectures", "bandwidth", "benefits",
            "best practices", "cadence", "catalysts for change", "channels", "collaboration and idea-sharing", "communities", "Mobilegeddon",
            "convergence", "core competencies", "Generation Z saturation", "Millennials saturation", "data", "deliverables", "e-business", "e-commerce", "e-markets",
            "e-tailers", "e-services", "Smart Factories and Industry 4.0", "expertise", "functionalities", "growth strategies", "human capital",
            "ideas", "imperatives", "infomediaries", "information", "infrastructures", "initiatives", "innovation",
            "intellectual capital", "interfaces", "internal or 'organic' sources", "leadership", "leadership skills",
            "manufactured products", "markets", "materials", "meta-services", "methodologies", "methods of empowerment", "metrics",
            "mindshare", "models", "networks", "niches", "niche markets", "opportunities", "'outside the box' thinking", "outsourcing",
            "paradigms", "partnerships", "platforms", "portals", "potentialities", "process improvements", "processes", "products",
            "quality vectors", "relationships", "resources", "results", "ROI", "scenarios", "schemas", "services", "solutions",
            "sources", "strategic theme areas", "supply chains", "synergy", "systems", "advanced machine learning", "technology",
            "testing procedures", "total linkage", "users", "deep learning", "vortals", "web-readiness", "web services", "fungibility",
            "clouds", "NoSql", "storage", "virtualisation", "Dev-Ops", "hyper-continuous delivery", "Scaled Agile Frameworks", "exacting technical readiness",
            "architecture", "slushy architecture", "gelatinous architectures", "micro-services", "lambda PaaS", "network interfaces", "deep webs", 
            "dark web exploitation", "gamification", "harnessed chaos theories", "wearable computing", "Big Data", "Data Ponds", 
            "Internet of Things", "hyper-convergence", "technological fashion", "Data Privacy", "Device Mash-ups", "v.Next JavaScript fashionables",
            "encryption", "Management 3.0", "generalising specialists", "deploy trains"
            };

        static GeneratorService()
        {
            RandomGenerator = new Random(DateTime.Now.Millisecond);
        }

        public string Generate()
        {
            var adverb = Adverbs.ElementAt(RandomGenerator.Next(0, Adverbs.Count - 1));
            var verb = Verbs.ElementAt(RandomGenerator.Next(0, Verbs.Count - 1));
            var adjective = Adjectives.ElementAt(RandomGenerator.Next(0, Adjectives.Count - 1));
            var noun = Nouns.ElementAt(RandomGenerator.Next(0, Nouns.Count - 1));
            return $"{adverb} {verb} {adjective} {noun}";
        }
    }
}
