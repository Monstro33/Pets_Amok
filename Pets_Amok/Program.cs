﻿using System;
using System.Collections.Generic;

namespace Pets_Amok
{
    class Program
    {
          
        static void Main(string[] args)
        {
            Shelter shelter = new Shelter();
            Menu(shelter);
        }       
        
        static void Menu(Shelter myshelter)
        {
            Console.WriteLine("Hello! Welcome to Virtual Pets, Inc. Here we have created a virtual interactive full spectrum pet experience.");
            Console.WriteLine("");
            Console.WriteLine("\nplease select from the options below.");
            Console.WriteLine("\n\t\t\t======== Main_Menu ========");
            Console.WriteLine("\t\t\tPress 1 to create your a pet ");
            Console.WriteLine("\t\t\tPress 2 to view available pets in shelter");
            Console.WriteLine("\t\t\tPress 4 to feed all of the pets in the shelter");
            Console.WriteLine("\t\t\tPress 5 to Adopt pet from the shelter");
            Console.WriteLine("\t\t\tPress 0 to quit");

            bool running = true;
           
            while (running)
            {
                string userInput = Console.ReadLine();

                 
                    switch (userInput)
                    {
                        case "1"://Create your pet
                            Console.WriteLine("\t\t\t\t Create your pet");
                            Console.Write("\nWhat would you like to name your pet?  ");
                            string name = Console.ReadLine();
                            Console.Write("How old is your pet?  ");
                            int age = Convert.ToInt32(Console.ReadLine());
                            Console.Write("What species is your pet?  ");
                            string species = Console.ReadLine();
                             
                            
                            myshelter.Add(name, age, species);
                            Console.WriteLine();
                           Console.Clear();
                             Console.WriteLine("Congratulations!\n\nYou have created " + name + " the " + species + " who is " + age + " years old. \n\n");
                             Console.WriteLine("We have moved " + name + " to our shelter");
                           Console.WriteLine("\n \n----Please select from the options below to continue----");
                            Console.WriteLine("\npress 2 to view all the animals in our shelter");
                            Console.WriteLine("press 0 to quit");
                            break;
                        case "2"://View the whole shelter
                            Console.Clear();
                            Console.WriteLine("\nView list of available pets in shelter \n");
                            myshelter.Print_List();
                            Console.WriteLine("\n\nPress 3 to select a pet to interact with");
                            break;
                        case "3":
                            Console.WriteLine("Please type ID to select your pet"); //Pet Selector
                            int id = Convert.ToInt32(Console.ReadLine());
                            myshelter.Select_Pet(id);
                            Console.Clear();
                            Console.WriteLine("You selected " + myshelter.Select_Pet(id).Name + ". " + myshelter.Select_Pet(id).Age + " years old  ");
                            Submenu(myshelter.Select_Pet(id));                           
                            break;
                        case "4":
                            Console.Clear();
                             myshelter.FeedAll();
                            Console.WriteLine("You fed the whole Shelter");
                            Console.WriteLine("Press 2 to return to the shelter");
                            break;
                        case "5"://Adopt a pet from the shelter
                            myshelter.Print_List();
                            Console.WriteLine("Please type ID of the pet you wish to adopt");
                            int ID = Convert.ToInt32(Console.ReadLine());
                            Console.Clear();
                            Console.WriteLine("Congratulations on your new adoption.");
                            Console.WriteLine("Press 2 to return to the shelter");
                            myshelter.Adopt(ID);                             
                            break;
                        case "0"://Close the program
                            running = false;
                            break;
                        default:
                            Console.WriteLine("You pressed wrong number");                          
                            break;                        
                    }
                    myshelter.TickAllOfThem();
            }
            
        }
        static void Submenu(PetClass anypet)
        {
            
            Console.WriteLine("\n\n\t\tPress 1 to feed " + anypet.Name +
                                "\n\t\tPress 2 to take " + anypet.Name + " the doctor " +
                                "\n\t\tPress 3 to play with " + anypet.Name +
                                 "\n\t\tPress 4 to view current status of " + anypet.Name +
                                 "\n\t\tPress 5 to rename  " + anypet.Name+
                                  "\n\n\t\tPress 0 return to the shelter", anypet.Name);
            bool runnapp = true;
            string input;
            do
            {
                input = Console.ReadLine();

                switch (input)
                {
                    case "1"://Feed your pet
                        Console.WriteLine("\t\t=====You have fed {0}===== ", anypet.Name);
                        anypet.Feed();
                        //anypet.Status();
                        break;
                    case "2": //Visit the veterinarian
                        Console.WriteLine("\t\t===== You  have taken {0} to the veterinarian ===== ", anypet.Name);
                        anypet.PetMaintenance();
                        //anypet.Status();
                        break;
                    case "3": //Play with your pet
                        Console.WriteLine("\t\t===== You  have played with {0} ===== ", anypet.Name);
                        anypet.Play();
                        //anypet.Status();
                        break;
                    case "4"://View status of your pet
                        Shelter.Status(anypet);
                        break;
                    case "5": //Rename Pet
                        Console.WriteLine("Please type the name in which you would like your pet to be called");
                        string new_name = Console.ReadLine();
                        anypet.Rename(new_name);
                        Console.WriteLine("Your Pet has New name "+new_name);
                        break;
                    case "0"://Close the program
                        runnapp = false;
                        Console.WriteLine("Press 2 to return back to the shelter to view all the pets we have");
                        break;
                    default:
                        Console.WriteLine("Invalid response please select option from the menu again");
                        break;                        
                }
            } while (runnapp);
        }
        
    }
}


