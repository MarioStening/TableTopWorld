using System.Collections.Generic;

using TableTopWorld.Core.EntityFramework;

namespace TableTopWorld.UI.CLI
{
    class Program
    {
        static void Main(string[] args)
        {
            Container Durabillity = new Container()
            {
                InheritsFrom = { } ,
                Name = "Durabillity" ,
                Properties =
                {
                    new DataDefinition<int>
                    {
                        IsStatic = true,
                    }
                }
            };
            DataDefinition<Container> DurabilityDataDefinition = new DataDefinition<Container>
            {
                Name = "Durabillity" ,

            };

            Container Item = new Container()
            {
                InheritsFrom = { } ,
                Name = "Item"
            };
            Container DurableItem = new Container()
            {
                InheritsFrom = { Item } ,
                Name = "DurableItem" ,
                Properties =
                {
                }
            };
            Container GenericWeapon = new Container()
            {
                InheritsFrom = { DurableItem } ,
                Name = "GenericWeapon"
            };
            Container Sword = new Container()
            {
                InheritsFrom = { GenericWeapon } ,
                Name = "Sword"
            };


            new Role
            {
                Users = new List<User>
                {
                    new User
                    {
                        Data = {
                            new Data<Container>
                            {
                                Name = "Player 1",
                            }
                        }
                    }
                }
            };
        }
    }
}
