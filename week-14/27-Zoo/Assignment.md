# The Zoo
- It should store food levels as integers
- There are two types of food meat and vegetables
- It should store a shit level that is 0 on the beginning
- It should have a constructor that takes two parameters the food levels as integers
- It should have an ```AddAnimal``` method that takes a new animal
- It should have a ```FeedAllAnimals```  method that feeds all the animals with the maximum food it can provide and it feed vegetables to herbivores and meat to carnivores
- It should have a ```RefillFood``` method that takes meat and vegetable levels and adds them to the stock
- It should have a ```SpendNormalDay``` method that calls the ```Live``` and ```Run``` methods of each animals and aggregates all the consumed foods as shit into the shit levels
- It should have a ```SpendQuarantineDay``` method that does the same as ```SpendNormalDay``` just only calls the ```Live```  method
- It should have a ```GetTheFullestStatus``` method that returns the status of the animal that is the least hungry, it should take a ```filterHerbivore``` parameter and if that is true it should only search between the carnivores
## The Animal
- Each animal should have a name and a boolean value if it is herbivore
- Each animal should store how much food they able to eat and a current belly level as integers
- Each animal should store a level how much food they consume from the belly while they live
- It should have an ```IsHerbivore``` method that returns if it is herbivore
- It should have an ```GetHunger```  method that returns how much food the animal needs to be full
- It should have an ```Eat```  method that takes food as integer and fills the belly with that amount. it throws an error if the food is more than it is able to eat
- It should have a ```Live```  method that returns how much food it consumed
- It should have a ```Run```  method works like Live but consumes 3 times more food
- It should have a ```GetStatus``` method that returns a string that states the name and the hungerlevel and wether the animal is herbivore
### Lion
> Carnivore
> Max food: 10
> Consume Level: 2
### Wolf
> Carnivore
> Max food: 5
> Consume Level: 1
### Elephant
> Herbivore
> Max food: 40
> Consume Level: 5