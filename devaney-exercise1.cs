namespace DevaneyExercise1 {
  using System.Collections.Generic;
  using System.Linq;


  public class InteractiveFiction {
     public static void Main() {
       //Initialize the world
       Location plant = new Location("Damp, Dark, Chamber");
       plant.description = "You've fallen down a trapdoor but landed on a surprisingly soft surface. Lucky this plant stuff's here, really.";
         
       plant.blocked = "You remember reading something in herbology about this plant...perhaps there's some spell you can wave out of your WAND to get out.\nThe plant tightens around you.\n";
       Location keys = new Location("Spacious Room");
       keys.description = "You here a fluttering of wings. On the wall opposite, three BROOMSTICKs are propped up next to a locked door to the north. The fluttering is coming from a flock of enchanted keys buzzing and flying around the ceiling.";
       keys.blocked = "The door is locked. The key you need is probably fluttering above you.";
       Location chess = new Location("Giant Chess Board"); chess.proceed = true;
       chess.description = "Flames rise up, blocking you on either side. You cannot go back. In the illumination of the fire, you see before you a giant chess BOARD.";
       Location potions = new Location("Sparse Potions Chamber");
       potions.description= "A row of potions in different colors and varying BOTTLES line the single shelf in the room. A short MESSAGE is posted above the shelf.";
       potions.blocked = "You can't pass the fire until you find the right potion(s) to get you through.";
       Location mirror = new Location("The Mirror of Erised");
       mirror.description = "The final room! You're so close. The Mirror of Erised stands as your final obstacle. You just need proof that you made it here, SOMETHING to return to the professor...";
       Location complete = new Location("Quest Complete");
       complete.description = "\n\n\n You've done it. You shan't fail Defense Against the Dark Arts after all.\nThank god Professor Quirrell gave you this opportunity.\nYou hop back on the Cleansweep and glide back through the chambers up the trapdoor, ready to hand Quirrell proof of your accomplishment....\n...this odd, cold, jagged little red stone."

   Location inv = new Location("Inventory");

       //Initialize all the things in the world
       Object self = new Object("self");
       self.about = "You are wearing your plain black schoolrobes and gripping your maple WAND very tightly. Stop sweating.";
       self.moveable = false;
       Object wand = new Object("wand");
       wand.about = "11 and 3 quarter inches. Maple. Core: Kelpie mane.";
       wand.place = inv; wand.need = plant;
       wand.valid = "wave"; wand.success = "Although you don't really know what to do, you wave your WAND about.\nBright blue fire bursts out of the end and the plant shirks away from the light. It looks like you can proceed down now.\n";
       wand.failure = "You squiggle your WAND in the air and gold and green sparks fly up, but nothing else happens.";
       Object bottles = new Object("bottles");
       bottles.about = "There is a dusty, squat BOTTLE with golden liquid. To its left, a skinny test TUBE with a dark blue potion.\nOn the other side, a green square glass DECANTER. There is also a tiny VIAL with a few drops of what \nlooks like blood left in it.";
       bottles.moveable = false; bottles.place = potions; bottles.valid = "drink";
       bottles.need = potions;
       bottles.success = "It'll take the best qualities of all the Hogwart Houses to get you through! You down all four potions, \nand feel a tingling spread throughout your body.\n\nYou're ready to pass through the fire.\n";
       Object blue = new Object("tube"); Object red = new Object("vial"); Object gold = new Object("bottle"); Object green = new Object("decanter");
       blue.about = red.about = green.about = gold.about = "Not much else to see from you initial inspection of the BOTTLES.";
       blue.place = red.place = green.place = gold.place = potions;
       blue.failure = red.failure = green.failure = gold.failure = "Yum. You down the potion quickly, and it refills itself before you even set it back down on the shelf.\nYou don't feel any different. This is an anti-climax.";
       blue.valid = red.valid = green.valid = gold.valid = "drink";
       Object broom = new Object("broomstick");
       broom.about = "There are three of those Cleansweep 7s the school stocks in the Quidditch sheds. However, one looks very well \nmaintained and you suppose you could fly it easily.";
       broom.place = keys; broom.need = keys;
       broom.valid = "fly"; broom.failure = "You sweep up some dust, but I don't think cleaning is going to help you here.";
       broom.success = "You grab a broomstick and nervously hop on, but find it responds easily to your slightest touch. You zoom around until\nyou find the largest key with a broken looking wing and snag it before descending down and tumbling off the broom in front of the door at the far end of the room.";
       Object chessBoard = new Object("board");
       chessBoard.about = "It looks like someone passed before you. Scattered pieces lie all across the board and to the sides, broken and twisted.\nThe black king and queen survey the destruction. triumphant. It might be best to get out of here aqap.";
       chessBoard.place = chess; chessBoard.moveable = false;
       chessBoard.valid = "play"; chessBoard.success = "There's really no need to play, given that someone already has before you."; chessBoard.need = chess;
       Object message = new Object("message");
       message.place = potions;
       message.about = "The message reads:\nSelect wisely if you would wish to proceed. Yellow to steel those loyal hearts, green to forward those ambitious few,\nred to match the courage of the fire, or blue to quell your rational perceptions of heat.";
       Object erised = new Object("mirror");
       erised.about = "You're reflected back in the mirror, dishelved and sweaty. But you're also holding SOMETHING you didn't notice before...";
       erised.place = mirror; erised.moveable = false;
       Object thing = new Object("something"); thing.moveable = false;
       thing.about = "A red jagged ROCK lies in your hand. Cool. You're into rocks.\nMaybe your friend that studies Geology will want it for Christmas.";
       Object stone = new Object("rock");
       stone.about = "It's misshapen but smooth, and quite cold to the touch.";
       stone.place = mirror; thing.place = mirror;


       ///put all objects in a list
       List<Object> allTheThings = new List<Object>{self,wand,broom,chessBoard,message,erised,stone,thing,bottles,blue,green,red,gold};

       //Link the locations together
       plant.south = keys;
       keys.north = chess;
       chess.south = keys;
       chess.north = potions;
       potions.south = chess;
       mirror.west = potions;
       potions.east = mirror;

       //Introduce the game briefly
       System.Console.WriteLine("----------------------------THE FORDBIDDEN THIRD FLOOR CORRIDOR-----------------------------------------");
       System.Console.WriteLine("You're breathing hard. You should have never taken that stupid extra credit challenge, especially as only a second year. The obstacles in the third floor corridor were meant for seventh years practicing for their N.E.W.Ts, but the challenge (and need to redeem your grade) was too great to resist.\nYou deftly pick the lock with a bobby pin. The first room in the forbidden third floor corridor is pitch dark. You take a cautious step forward --");
       System.Console.WriteLine("");

       //set start Location
       Location currentLocation = plant;
       bool timeToQuit = false;
       while(!timeToQuit){
         self.place = currentLocation;
         System.Console.WriteLine("");
         System.Console.WriteLine(currentLocation.Name);
         System.Console.WriteLine(currentLocation.description);

         //Get a command from the user
         System.Console.Write("> ");
         string fullCommand = System.Console.ReadLine();
         Commands newCommand = new Commands(fullCommand);

         //Check if command is to quit
         if (timeToQuit=newCommand.checkFirst()){
           break;
         }
         //if command is not quit:
         else{
           Location place = newCommand.decide(currentLocation);
          //if the player requested to move or typed an invalid command
           if (currentLocation!=place){
             if (place != null){
               //if a place object was not returned, player did not type valid command
               //change Location to new location if player moved
               currentLocation = place;
             }
           }
           //else if the place stayed the same as the current location, player asked to do something in the room or failed to move
           else{
             //take first command on object - automatically prints to player appropriate text if request is on viewing or changing inventory
             newCommand.inv(currentLocation,allTheThings,inv);
             //if player is in final room and has the stone
             if(currentLocation == mirror && stone.place == inv){
               currentLocation == complete;
               /* System.Console.WriteLine("\n\n\n");
                System.Console.WriteLine("You've done it. You shan't fail Defense Against the Dark Arts after all.");
                System.Console.WriteLine("Thank god Professor Quirrell gave you this opportunity.");
                System.Console.WriteLine("You hop back on the Cleansweep and glide back through the chambers up the trapdoor, ready to hand Quirrell proof of your accomplishment....");
                System.Console.WriteLine("...this odd, cold, jagged little red stone."); */
             }
            }
          }
        }
      
    }
  }

     public class Location {
       //This is an example of how to use get/set methods
       private string name;
       public string Name {
         get {
           return name;
         }
         set {
           name = value;
         }
       }
       public string blocked = "";
       public string description = "";
       public bool proceed = false;
       public Location north = null;
       public Location south = null;
       public Location east = null;
       public Location west = null;
       public Location(string n) {
         this.Name = n;
       }
       public Location direction(string d){
         if (d == "south" || d == "s" || d == "down"){
           return this.south;
         }
         else if(d=="north" || d == "n"){
           return this.north;
         }
         else if(d=="west"||d=="w"){
           return this.west;
         }
         else if(d=="east"||d=="e"){
           return this.east;
         }
         else{return null;}
       }
     }

     public class Object{
       //objects need descriptions, actions, and rooms they are linked to
       private string thing;
       public bool moveable = true;
       public string valid = null;
       public Location place = null;
       public Location need = null;
       public string about = "";
       public string success = "";
       public string failure = "Well that didn't seem to do much.";

       public string Name {
         get {
           return thing;
         }
         set {
           thing = value;
         }
       }

       public Object (string o){
         this.Name = o;
       }

     }

     public class Commands {
         private string command;
         private string[] parseLine;
         private string helpText = "Type \"go\", \"walk\" or \"move\" to move. \nChoose your direction: \"n\" or \"north\" to go north, \"s\" or \"south\"  for south, etc.\nType \"i\" for inventory. Type \"x\" to examine an object or your surroundings. Type \"take\" or \"drop\" to pick up and drop items.\n Items in CAPS will give you clues as to what items you, your SELF can act upon.\n(For example: Try 'x self.')\nCertain objects may require more specific commands, which you shall have to discover for yourself.\n";
         public string Name{
           get{
             return command;
           }
           set{
             command = value;
             parseLine = value.Split(' ');
           }
         }
         public Commands (string n){
           this.Name = n;
         }
         private string act{
           get{
             return this.parseLine[0];
           }
         }
         private string key{
           get{
             return this.parseLine[1];
           }
         }
         //handle quit/help before trying to do anything
         public bool checkFirst(){
           if (this.act == "quit") {
             return true;
           }
           else if (this.act == "help"){
             System.Console.WriteLine(helpText);
             return false;
           }
           else{return false;}
         }
         //determine whether player is trying to move, or utilize inventory
         public Location decide(Location current){
           if (parseLine[0] == "go" || parseLine[0] == "walk" || parseLine[0] == "move"){
             current=this.move(current);
           }
           else if (parseLine[0] == "take" || parseLine[0] == "drop" || parseLine[0] == "i" || parseLine[0] == "x" || parseLine[0] == "use" || this.act == "drink" || this.act == "wave" || this.act == "fly" || this.act == "play"){
             return current;
           }
           else if(parseLine[0] != "help"){
             System.Console.WriteLine("I did not understand your request. Type 'help' for valid commands\n");
             current = null;
           }
           return current;
         }
         //determine what is to the direction given and go that way
         private Location move(Location current){
           if (current.direction(this.key)==null){
             System.Console.WriteLine("There is nothing to the "+parseLine[1]+".\n");
             return current;
           }
           else{
             Location newPlace = current.direction(this.key);
             if(current.proceed == true){
               return newPlace;
             }
             else{
               System.Console.WriteLine("You can't go that way.");
               System.Console.WriteLine(current.blocked);
               return null;
             }
           }
         }
         //inventory actions
         public void inv(Location current, List<Object> all, Location inv){
           if(this.act == "x"){
             if (all.Find(x => x.Name == this.key && (x.place == current || x.place == inv)) == null){
               System.Console.WriteLine("There is nothing of that nature here.\n");
             }
             else{
               System.Console.WriteLine((all.Find(x => x.Name == this.key)).about+"\n");
             }
           }
           else if(this.act=="i"){
               System.Console.WriteLine("You have in your (magically expandable) pockets: ");
               foreach(Object item in all){
                   if(item.place == inv){
                       System.Console.WriteLine(item.Name);
                   }
                 }
                System.Console.WriteLine("");
             }
           else if(this.act == "take"){
               Object found = (all.Find(x => x.Name == this.key && (x.place == current) && x.moveable));
               if (found != null){
                  found.place = inv;
                  System.Console.WriteLine("Taken");
                  System.Console.WriteLine("");
               }
               else {
                   System.Console.WriteLine("You cannot take "+this.key+" or it does not exist.");
                 }
              }
             else if(this.act == "drop"){
               if (all.Find(x => x.Name == this.key && (x.place == inv)) != null){
                    (all.Find(x => x.Name == this.key && (x.place == inv))).place = current;
                     System.Console.WriteLine("Dropped");
                     System.Console.WriteLine("");
                }
                else{
                  System.Console.WriteLine("You have nothing of that nature in your inventory.");
                }
              }
          else if(this.act == "help" || this.act == "go" || this.act == "walk" || this.act == "move"){
              return;
            }
           else {
               Object found = (all.Find(x => x.Name == this.key));
               if (found == null || (found.place != inv && found.place != current)){
                 System.Console.WriteLine("Sorry, I can find whatever you're trying to use here.");
                 System.Console.WriteLine("");
               }
               else if(found.need == current && found.valid == this.act){
                 current.proceed = true;
                 //print success statement indicating to player that they can move forward.
                 System.Console.WriteLine(found.success);
               }
               else{
                  //if item action did not work, print failure statement or default failure statement for each object
                  System.Console.WriteLine(found.failure);
                  System.Console.WriteLine("");
               }
            }
          }
         }
       }
