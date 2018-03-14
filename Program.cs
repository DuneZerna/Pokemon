using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokemon
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Pokemon> roster = new List<Pokemon>();
            List<String> pokemonNames = new List<String>();
            List<Pokemon> matchUp = new List<Pokemon>(); // List that holds the two fighting pokemons
            List<String> bulbasaurMoveNames = new List<String>(); // List that holds the string name of the moves
            List<String> charmanderMoveNames = new List<String>(); // List that holds the string name of the moves
            List<String> squirtleMoveNames = new List<String>(); // List that holds the string name of the moves

            //List that hold moves for each Pokemon
            List<Move> BulbasaurMove = new List<Move>();
            List<Move> CharmanderMove = new List<Move>();
            List<Move> SquirtleMove = new List<Move>();


            //Initialises the moves
            Move Tail = new Move("Tail");
            Move Claw = new Move("Claw");
            Move Leaf = new Move("Leaf");

            Move Headbutt = new Move("Headbutt");
            Move Bodyslam = new Move("Bodyslam");
            Move Watergun = new Move("Watergun");

            Move AirAttack = new Move("Air Attack");
            Move Ember = new Move("Ember");
            Move Fireblast = new Move("Fireblast");

            // Add moves to a specific Pokeman
            BulbasaurMove.Add(Tail);
            bulbasaurMoveNames.Add("Tail");
            BulbasaurMove.Add(Claw);
            bulbasaurMoveNames.Add("Claw");
            BulbasaurMove.Add(Leaf);
            bulbasaurMoveNames.Add("Leaf");

            SquirtleMove.Add(Headbutt);
            squirtleMoveNames.Add("Headbutt");
            SquirtleMove.Add(Bodyslam);
            squirtleMoveNames.Add("Bodyslam");
            SquirtleMove.Add(Watergun);
            squirtleMoveNames.Add("Watergun");

            CharmanderMove.Add(AirAttack);
            charmanderMoveNames.Add("Air Attack");
            CharmanderMove.Add(Ember);
            charmanderMoveNames.Add("Ember");
            CharmanderMove.Add(Fireblast);
            charmanderMoveNames.Add("Fireblast");


            // Initialises the pokemons
            Pokemon Bulbasaur = new Pokemon("Bulbasaur", 10, 8, 8, 200, Elements.Grass, BulbasaurMove);
            Pokemon Charmander = new Pokemon("Charmander", 10, 7, 9, 200, Elements.Fire, CharmanderMove);
            Pokemon Squirtle = new Pokemon("Squirtle", 10, 9, 7, 200, Elements.Water, SquirtleMove);

            // Adds the pokemons to the roster list
            roster.Add(Bulbasaur);
            roster.Add(Charmander);
            roster.Add(Squirtle);


            // Adds the string names to the list // This is alternative way of printing strings, since I don't know how to print the strings in an object
            pokemonNames.Add("Bulbasaur");
            pokemonNames.Add("Charmander");
            pokemonNames.Add("Squirtle");

            // INITIALIZE YOUR THREE POKEMONS HERE

            Console.WriteLine("Welcome to the world of Pokemon!\nThe available commands are list/fight/heal/quit");

            while (true)
            {
                Console.WriteLine("\nPlease enter a command");
                switch (Console.ReadLine())
                {
                    case "list":
                        
                        //pokemonNames.ForEach(Console.WriteLine);  // Writes every item in the pokemonNames list
                        foreach(Pokemon p in roster){
                            Console.WriteLine(p.Name);
                        }
                        break;

                        case "fight":
                        //PRINT INSTRUCTIONS AND POSSIBLE POKEMONS (SEE SLIDES FOR EXAMPLE OF EXECUTION)
                        Console.WriteLine("Choose who should fight? " + "\n" + "Bulbasaur, Charmander or Squirtle?");
                        System.Threading.Thread.Sleep(1500);
                        Console.WriteLine("Example: Bulbasaur Charmander");

                       

                        //READ INPUT, REMEMBER IT SHOULD BE TWO POKEMON NAMES
                        string input = Console.ReadLine();
                        string[] chosenPokemons = input.Split(' '); //Split input into several substrings and puts them in the chosenPokemons variable
                        

                        // This part adds the chosen pokemons to a matchup list, based on input string
                        // Player gets the [0] pokemon in the array and Enemy gets [1] in the array

                        if (chosenPokemons.Length != 2)
                        {
                            Console.WriteLine("You have not done as instructed fool!");
                            continue;
                        }

                        if (chosenPokemons[0] == ("Bulbasaur"))
                        {
                            matchUp.Insert(0, Bulbasaur);
                        }
                        if (chosenPokemons[0] == ("Squirtle"))
                        {
                            matchUp.Insert(0, Squirtle);
                        }
                        if (chosenPokemons[0] == ("Charmander"))
                        {
                            matchUp.Insert(0, Charmander);
                        }

                        if (chosenPokemons[1] == ("Bulbasaur"))
                        {
                            matchUp.Add(Bulbasaur);
                        }
                        if (chosenPokemons[1] == ("Squirtle"))
                        {
                            matchUp.Add(Squirtle);
                        }
                        if (chosenPokemons[1] == ("Charmander"))
                        {
                            matchUp.Add(Charmander);
                        }

                        
                        System.Threading.Thread.Sleep(2000);

                        //prints which pokemons were chosen
                        foreach (var chosen in chosenPokemons)
                        {
                            Console.WriteLine("You have added " + chosen + " to the fight!");
                        }

                        System.Threading.Thread.Sleep(2000);

                        Console.WriteLine("Preparing match...");
                       
                        //BE SURE TO CHECK THE POKEMON NAMES THE USER WROTE ARE VALID (IN THE ROSTER) AND IF THEY ARE IN FACT 2!
                        Pokemon player = matchUp.First();
                        Pokemon enemy = matchUp.Last();

                        if (player == null || enemy == null || player == null && enemy == null)
                        {
                            Console.WriteLine("You have not chosen a valid Pokemon, try again");
                            input = Console.ReadLine();
                        }

                        //if everything is fine and we have 2 pokemons let's make them fight
                        if (player != null && enemy != null && player != enemy)
                        {
                            Console.WriteLine("A wild " + enemy.Name + " appears!");
                            Console.WriteLine(player.Name + " I choose you! ");

                            //BEGIN FIGHT LOOP
                            while (player.Hp > 0 && enemy.Hp > 0)
                            {
                                int damage = player.Attack(enemy);

                                   
                                //PRINT POSSIBLE MOVES DEPENDING ON WHICH POKEMON YOU CHOOSE
                                switch (player.Name)
                                {

                                    case "Bulbasaur": // The player gets Bulbasaur
                                        System.Threading.Thread.Sleep(1000);
                                        bulbasaurMoveNames.ForEach(Console.WriteLine);
                                        System.Threading.Thread.Sleep(1000);
                                        Console.WriteLine("What move should we use?");

                                        string choiceMoveB = Console.ReadLine(); //Holds the choice of move the player made

                                        switch (choiceMoveB) //The player chooses between Bulbasaur's moves
                                        {
                                            case "Tail":
                                                System.Threading.Thread.Sleep(1500);
                                                Console.WriteLine(player.Name + " uses " + player.Moves[0].Name + ". " + enemy.Name + " loses " + damage + " HP");
                                                System.Threading.Thread.Sleep(1000);
                                                Console.WriteLine(enemy.Name + " has " + enemy.Hp + " left.");
                                                break;

                                            case "Claw":
                                                System.Threading.Thread.Sleep(1500);
                                                Console.WriteLine(player.Name + " uses " + player.Moves[1].Name + ". " + enemy.Name + " loses " + damage + " HP");
                                                System.Threading.Thread.Sleep(1000);
                                                Console.WriteLine(enemy.Name + " has " + enemy.Hp + " left.");
                                                break;

                                            case "Leaf":
                                                System.Threading.Thread.Sleep(1500);
                                                Console.WriteLine(player.Name + " uses " + player.Moves[2].Name + ". " + enemy.Name + " loses " + damage + " HP");
                                                System.Threading.Thread.Sleep(1000);
                                                Console.WriteLine(enemy.Name + " has " + enemy.Hp + " left.");
                                                break;
                                        }
                                        break;

                                    case "Charmander":
                                        System.Threading.Thread.Sleep(1000);
                                        charmanderMoveNames.ForEach(Console.WriteLine);
                                        System.Threading.Thread.Sleep(1000);
                                        Console.Write("What move should we use? ");

                                        string choiceMoveC = Console.ReadLine();

                                        switch (choiceMoveC) //The player chooses between Bulbasaur's moves
                                        {
                                            case "Air Attack":
                                                System.Threading.Thread.Sleep(1500);
                                                Console.WriteLine(player.Name + " uses " + player.Moves[0].Name + ". " + enemy.Name + " loses " + damage + " HP");
                                                System.Threading.Thread.Sleep(1000);
                                                Console.WriteLine(enemy.Name + " has " + enemy.Hp + " left.");
                                                break;

                                            case "Ember":
                                                System.Threading.Thread.Sleep(1500);
                                                Console.WriteLine(player.Name + " uses " + player.Moves[1].Name + ". " + enemy.Name + " loses " + damage + " HP");
                                                System.Threading.Thread.Sleep(1000);
                                                Console.WriteLine(enemy.Name + " has " + enemy.Hp + " left.");
                                                break;

                                            case "Fireblast":
                                                System.Threading.Thread.Sleep(1500);
                                                Console.WriteLine(player.Name + " uses " + player.Moves[2].Name + ". " + enemy.Name + " loses " + damage + " HP");
                                                System.Threading.Thread.Sleep(1000);
                                                Console.WriteLine(enemy.Name + " has " + enemy.Hp + " left.");
                                                break;
                                        }

                                        break;

                                    case "Squirtle":
                                        System.Threading.Thread.Sleep(1000);
                                        squirtleMoveNames.ForEach(Console.WriteLine);
                                        System.Threading.Thread.Sleep(1000);
                                        Console.Write("What move should we use?");

                                        string choiceMoveS = Console.ReadLine();
                                        switch (choiceMoveS) //The player chooses between Bulbasaur's moves
                                        {
                                            case "Headbutt":
                                                System.Threading.Thread.Sleep(1500);
                                                Console.WriteLine(player.Name + " uses " + player.Moves[0].Name + ". " + enemy.Name + " loses " + damage + " HP");
                                                System.Threading.Thread.Sleep(1000);
                                                Console.WriteLine(enemy.Name + " has " + enemy.Hp + " left.");
                                                break;

                                            case "Bodyslam":
                                                System.Threading.Thread.Sleep(1500);
                                                Console.WriteLine(player.Name + " uses " + player.Moves[1].Name + ". " + enemy.Name + " loses " + damage + " HP");
                                                System.Threading.Thread.Sleep(1000);
                                                Console.WriteLine(enemy.Name + " has " + enemy.Hp + " left.");
                                                break;

                                            case "Watergun":
                                                System.Threading.Thread.Sleep(1500);
                                                Console.WriteLine(player.Name + " uses " + player.Moves[2].Name + ". " + enemy.Name + " loses " + damage + " HP");
                                                System.Threading.Thread.Sleep(1000);
                                                Console.WriteLine(enemy.Name + " has " + enemy.Hp + " left.");
                                                break;
                                        }

                                        break;
                                }


                                    //if the enemy is not dead yet, it attacks
                                    if (enemy.Hp > 0)
                                    {
                                        //CHOOSE A RANDOM MOVE BETWEEN THE ENEMY MOVES AND USE IT TO ATTACK THE PLAYER
                                        Random rand = new Random();
                                    /*the C# random is a bit different than the Unity random
                                     * you can ask for a number between [0,X) (X not included) by writing
                                     * rand.Next(X) 
                                     * where X is a number 
                                     */
                                    int enemyMove = rand.Next(roster.Count - 1);
                                    int enemyDamage = enemy.Attack(player);

                                        //print the move and damage
                                        Console.WriteLine(enemy.Name + " uses " + enemy.Moves[enemyMove].Name + ". " + player.Name + " loses " + enemyDamage + " HP");
                                        System.Threading.Thread.Sleep(1000);
                                        Console.WriteLine(player.Name + " has " + player.Hp + " left.");
                                    }
                                }

                              
                                //The loop is over, so either we won or lost
                                if (enemy.Hp <= 0)
                                {
                                    Console.WriteLine(enemy.Name + " faints, you won!");
                                }
                                else
                                {
                                    Console.WriteLine(player.Name + " faints, you lost...");
                                }
                            }
                        
                        
                        //otherwise let's print an error message
                        else
                        {
                            Console.WriteLine("Invalid pokemons");
                        }
                        break;
                        

                    case "heal":
                        //RESTORE ALL POKEMONS IN THE ROSTER

                        Bulbasaur.Restore();
                        Charmander.Restore();
                        Squirtle.Restore();
                        Console.WriteLine("All pokemons have been healed");
                        break;

                    case "quit":
                        Console.WriteLine("You are now exiting the game");
                        System.Threading.Thread.Sleep(3000);
                        Environment.Exit(0);
                        break;

                    default:
                        Console.WriteLine("Unknown command");
                        break;
                }
            }
        }
    }
}
