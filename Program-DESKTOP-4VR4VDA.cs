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


            //List that hold moves for each Pokemon
            List<Move> BulbasaurMove = new List<Move>();
            List<Move> CharmanderMove = new List<Move>();
            List<Move> SquirteMove = new List<Move>();


            //Initialises the moves
            Move Derp = new Move("Derp[0]");
            Move Herp = new Move("Herp[1]");
            Move Moon = new Move("Moon[2]");

            Move Awesome = new Move("Awesome Move[0]");
            Move Epic = new Move("Epic Move[1]");
            Move Legendary = new Move("Legendary Move[2]");

            // Add moves to a specific Pokeman
            BulbasaurMove.Add(Derp);
            BulbasaurMove.Add(Herp);
            BulbasaurMove.Add(Moon);

            SquirteMove.Add(Derp);
            SquirteMove.Add(Epic);
            SquirteMove.Add(Moon);

            CharmanderMove.Add(Awesome);
            CharmanderMove.Add(Epic);
            CharmanderMove.Add(Legendary);


            // Initialises the pokemons
            Pokemon Bulbasaur = new Pokemon("Bulbasaur", 10, 10, 1, 100, Elements.Fire, BulbasaurMove);
            Pokemon Charmander = new Pokemon("Charmander", 10, 10, 1, 100, Elements.Water, CharmanderMove);

            // Adds the pokemons to the roster list
            roster.Add(Bulbasaur);
            roster.Add(Charmander);


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

                        foreach (var value in roster)
                        {
                            Console.WriteLine(value);
                        }
                        
                        pokemonNames.ForEach(Console.WriteLine);  // Writes every item in the pokemonNames list
                        break;

                    case "fight":
                        //PRINT INSTRUCTIONS AND POSSIBLE POKEMONS (SEE SLIDES FOR EXAMPLE OF EXECUTION)
                        Console.Write("Choose who should fight(");

                        //READ INPUT, REMEMBER IT SHOULD BE TWO POKEMON NAMES
                        string input = Console.ReadLine();
                        //BE SURE TO CHECK THE POKEMON NAMES THE USER WROTE ARE VALID (IN THE ROSTER) AND IF THEY ARE IN FACT 2!
                        Pokemon player = null;
                        Pokemon enemy = null;

                        //if everything is fine and we have 2 pokemons let's make them fight
                        if (player != null && enemy != null && player != enemy)
                        {
                            Console.WriteLine("A wild " + enemy.Name + " appears!");
                            Console.Write(player.Name + " I choose you! ");

                            //BEGIN FIGHT LOOP
                            while (player.Hp > 0 && enemy.Hp > 0)
                            {
                                //PRINT POSSIBLE MOVES
                                Console.Write("What move should we use? (");

                                //GET USER ANSWER, BE SURE TO CHECK IF IT'S A VALID MOVE, OTHERWISE ASK AGAIN
                                int move = -1;

                                //CALCULATE AND APPLY DAMAGE
                                int damage = -1;

                                //print the move and damage
                                Console.WriteLine(player.Name + " uses " + player.Moves[move].Name + ". " + enemy.Name + " loses " + damage + " HP");

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
                                    int enemyMove = -1;
                                    int enemyDamage = -1;

                                    //print the move and damage
                                    Console.WriteLine(enemy.Name + " uses " + enemy.Moves[enemyMove].Name + ". " + player.Name + " loses " + enemyDamage + " HP");
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

                        Console.WriteLine("All pokemons have been healed");
                        break;

                    case "quit":
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
