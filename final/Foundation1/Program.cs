using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
// I used chatGPT to assist with saving the lists to the files deaths.txt and completed.txt and the timer challenge
class Program {
    static void Main(string[] args) {
        Q q = new Q();
        bool done = false;
        List<string> completedChallenges = new List<string>();
        List<DeathEntry> deathHistory = new List<DeathEntry>();

        // Load completed challenges and death records
        if (File.Exists("completed.txt")) {
            completedChallenges.AddRange(File.ReadAllLines("completed.txt"));
        }
        if (File.Exists("deaths.txt")) {
            foreach (var line in File.ReadAllLines("deaths.txt")) {
                Console.WriteLine("Loaded death entry: " + line);
            }
        }

        do {
            Console.WriteLine("Welcome to Minecraft youtube assistant program!");
            Console.WriteLine("1. Random challenge generator ");
            Console.WriteLine("2. Death progress tracker ");
            Console.WriteLine("3. Timer based challenges ");
            Console.WriteLine("4. View death progress entries ");
            Console.WriteLine("5. View completed challenges ");
            Console.WriteLine("6. Quit ");
            Console.Write("Console: ");
            int program_choice = int.Parse(Console.ReadLine());

            if (program_choice == 1) {
                
                Challenge random_challenge = SelectRandomChallenge();
                string chosenChallenge = random_challenge?.TheChallenge();
                if (!string.IsNullOrEmpty(chosenChallenge)) {
                    Console.WriteLine(chosenChallenge);
                    string completionStatus = q.a("Did you complete the challenge? (yes/no): ").ToLower();
                    string challengeRecord = completionStatus == "yes" 
                        ? $"{chosenChallenge} (Completed)"
                        : $"{chosenChallenge} (Not Completed)";

                    File.AppendAllText("completed.txt", challengeRecord + Environment.NewLine);
                    Console.WriteLine("Challenge status recorded!");
                }
            } else if (program_choice == 2) {
                // Death progress tracker 
                DeathEntry entry = new DeathEntry();

                Console.WriteLine("How far did you get? ");
                Console.WriteLine("1. Overworld ");
                Console.WriteLine("2. Nether ");
                Console.WriteLine("3. End ");
                int world_progress = int.Parse(q.a("Console: "));

                entry.Food = q.a("How much food did you have? ");
                entry.Materials = q.a("How much iron/diamond/gold did you have? ");

                if (world_progress == 1) {
                    entry.World = "Overworld";
                    string bucket = q.a("Water bucket? (yes/no) ");
                    string village = q.a("Village? (yes/no) ");
                    string pearls = q.a("How many ender pearls? ");
                    entry.ExtraInfo = $"Bucket: {bucket}, Village: {village}, Pearls: {pearls}";
                } else if (world_progress == 2) {
                    entry.World = "Nether";
                    string bastion = q.a("Bastion? (yes/no) ");
                    string fortress = q.a("Fortress? (yes/no) ");
                    string pearls = q.a("How many ender pearls? ");
                    entry.ExtraInfo = $"Bastion: {bastion}, Fortress: {fortress}, Pearls: {pearls}";
                } else if (world_progress == 3) {
                    entry.World = "End";
                    string crystals = q.a("Crystals destroyed? (yes/no) ");
                    string dragon = q.a("Dragon killed? ");
                    string island = q.a("How much end island exploring did you do? ");
                    entry.ExtraInfo = $"Crystals: {crystals}, Dragon: {dragon}, End Island: {island}";
                }

                entry.CauseOfDeath = q.a("What killed you? ");
                deathHistory.Add(entry);
                File.AppendAllText("deaths.txt", entry.ToString() + Environment.NewLine);
                Console.WriteLine("Death record saved!");

            } else if (program_choice == 3) {
                string time = q.a("How many seconds for this challenge are you looking for? ");
                int seconds;
                if (int.TryParse(time, out seconds) && seconds > 0) {
                    List<string> timedChallenges = new List<string> {
                        "Build a shelter before time runs out.",
                        "Find and cook a food item.",
                        "Craft a full set of stone tools.",
                        "Survive a full Minecraft night.",
                        "Find and collect 10 pieces of coal.",
                        "Tame a pet (wolf or cat).",
                        "Travel 300 blocks in one direction.",
                        "Find a village and trade with a villager.",
                        "Collect one of each flower type you can find.",
                        "Create a nether portal frame (no lighting required)."
                    };

                    Random random = new Random();
                    string chosen = timedChallenges[random.Next(timedChallenges.Count)];
                    string completed = $"[Timer: {seconds} seconds] {chosen}";

                    Console.WriteLine($"Your challenge: {chosen}");
                    Console.WriteLine($"Starting countdown for {seconds} seconds...");

                    // Start countdown
                    for (int i = seconds; i >= 0; i--) {
                        Console.Clear();
                        Console.WriteLine($"Time remaining: {i} seconds");
                        Console.WriteLine($"Your challenge: {chosen}");
                        Thread.Sleep(1000); 
                    }

                    // Challenge completed
                    Console.WriteLine("\nTime's up! Challenge completed.");
                    string completionStatus = q.a("Did you complete the challenge? (yes/no): ").ToLower();

                    if (completionStatus == "yes") {
                        Console.WriteLine("Challenge marked as completed.");
                        completedChallenges.Add(completed);
                        File.AppendAllText("completed.txt", completed + Environment.NewLine);
                    } else {
                        Console.WriteLine("Challenge was not completed.");
                        completed += " (Not Completed)";
                        File.AppendAllText("completed.txt", completed + Environment.NewLine);
                    }
                } else {
                    Console.WriteLine("Invalid input. Please enter a positive number of seconds.");
                }
            } else if (program_choice == 4) {
                Console.WriteLine("\nDeath Progress Entries:");
                if (File.Exists("deaths.txt")) {
                    string[] deaths = File.ReadAllLines("deaths.txt");
                    foreach (string d in deaths) {
                        Console.WriteLine("- " + d);
                    }
                } else {
                    Console.WriteLine("No death entries recorded yet.");
                }
                Console.WriteLine();
            } else if (program_choice == 5) {
                Console.WriteLine("\nCompleted Challenges:");
                if (completedChallenges.Count == 0) {
                    Console.WriteLine("None yet!");
                } else {
                    foreach (string c in completedChallenges) {
                        Console.WriteLine("- " + c);
                    }
                }
                Console.WriteLine();
            } else if (program_choice == 6) {
                done = true;
            }
        } while (!done);
    }

    public static Challenge SelectRandomChallenge() {
        Console.WriteLine("What type of challenge are you looking for?");
        Console.WriteLine("1. Survival ");
        Console.WriteLine("2. Combat ");
        Console.WriteLine("3. Building ");
        Console.WriteLine("4. Quit ");
        Console.Write("Console: ");
        int random_challenge_choice = int.Parse(Console.ReadLine());
        Challenge challenge = null;

        if (random_challenge_choice == 1) {
            challenge = new Survival();
        } else if (random_challenge_choice == 2) {
            challenge = new Combat();
        } else if (random_challenge_choice == 3) {
            challenge = new Building();
        }
        return challenge;
    }
}

public class Challenge {
    public virtual string TheChallenge() {
        return "override the challenge";
    }
}

public class Survival : Challenge {
    public override string TheChallenge() {
        List<string> survivalChallenges = new List<string> {
            "Don't sprint for the next 10 minutes.",
            "Eat only raw food for one Minecraft day.",
            "Survive a night without placing or using any light sources.",
            "Go mining with only one tool of each type.",
            "Stay outside all night without armor or weapons.",
            "Walk in a straight line for 5 minutes, no turning.",
            "Travel 500 blocks without touching grass blocks.",
            "Survive underground for 3 Minecraft days.",
            "Don't use any tools for 10 minutes.",
            "Live entirely off the land (no farming) for 2 days.",
            "Don't kill any animals for food today.",
            "Don't enter a shelter from dusk till dawn.",
            "Only eat what you fish for the next 2 days.",
            "Gather 5 different food types without crafting.",
            "Cross a desert biome without stopping.",
            "Don't sleep through the night—stay active!",
            "Don't place or break any blocks for 5 minutes.",
            "Survive in the Nether without armor for 10 minutes.",
            "Avoid water for a full day cycle.",
            "Spend 1 day using only your non-dominant hand (IRL).",
            "Swap controls (rebind WASD) and survive the night."
        };
        Random random = new Random();
        return survivalChallenges[random.Next(survivalChallenges.Count)];
    }
}

public class Combat : Challenge {
    public override string TheChallenge() {
        List<string> combatChallenges = new List<string> {
            "Fight only with a bow for the next 5 hostile mobs.",
            "Defeat 3 mobs without wearing any armor.",
            "Use only a wooden sword until sunset.",
            "Win a fight using only snowballs and knockback.",
            "Fight a mob blindfolded (have a friend guide you).",
            "Defeat a creeper using only melee—no running away.",
            "Clear a cave without placing any torches.",
            "Fight with inverted mouse settings for 5 minutes.",
            "Defeat a mob while standing in water.",
            "Fight 3 skeletons with no shield.",
            "Use only your fists to defeat 2 zombies.",
            "Battle a spider jockey using only eggs.",
            "Take on a witch without healing items.",
            "Win a fight in third-person mode.",
            "Fight mobs on a frozen lake—no crouching!",
            "Defend a villager from a pillager raid without armor.",
            "Only fight using flint and steel (burn the mobs!).",
            "Take on a horde of mobs at night without retreating.",
            "Trap and defeat a creeper without it exploding.",
            "Win a fight without jumping or sprinting.",
            "Use only potions to survive a cave fight.",
            "Use one arrow to defeat two mobs (multikill!)."
        };
        Random random = new Random();
        return combatChallenges[random.Next(combatChallenges.Count)];
    }
}

public class Building : Challenge {
    public override string TheChallenge() {
        List<string> buildingChallenges = new List<string> {
            "Build a base in the Nether before the next nightfall.",
            "Create a treehouse using only jungle wood.",
            "Decorate a house using only blocks you find in the desert.",
            "Build a statue of your Minecraft character.",
            "Create a redstone door that opens automatically.",
            "Build a bridge across a ravine without crouching.",
            "Build a sky base with no ladders or elevators.",
            "Recreate a famous landmark using only cobblestone.",
            "Build a secret hideout underground.",
            "Build a house entirely underwater (no conduit).",
            "Design a themed village (e.g., mushroom or ice).",
            "Build a lighthouse that actually emits light.",
            "Create a rollercoaster with at least 3 twists.",
            "Build a working piston door with hidden entrance.",
            "Design and build a trap for mobs using redstone.",
            "Make a cozy cottage with only natural materials.",
            "Create a floating island with a small base on it.",
            "Build a ship or boat with cabins inside.",
            "Build a nether portal shrine with decorations.",
            "Make a library with bookshelves and secret passages."
        };
        Random random = new Random();
        return buildingChallenges[random.Next(buildingChallenges.Count)];
    }
}

public class DeathEntry {
    public string World { get; set; }
    public string Food { get; set; }
    public string Materials { get; set; }
    public string ExtraInfo { get; set; }
    public string CauseOfDeath { get; set; }

    public override string ToString() {
        return $"World: {World}, Food: {Food}, Materials: {Materials}, Info: {ExtraInfo}, Cause of Death: {CauseOfDeath}";
    }
}

public class Q {
    public string a(string question) {
        Console.Write(question);
        return Console.ReadLine();
    }
}
