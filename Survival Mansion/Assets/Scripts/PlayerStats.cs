using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour {

    public int strength = 500;//Determines the amount of health a character has, as well as how effective he might be with melee weapons, carrying items, pushing around furniture, or holding doors.
                              //Eventually allows handling of heavier items.

    public int agility = 500;//How fast a character can move around on the map and outrun potential danger. Also determines the character’s ability to use ranged weapons.
                             //Eventually allows interaction with certain bits of the map like climbing ivy.

    public int guile = 500;//Whether a character can hide well enough to not be seen, or sneak quietly enough to not be heard by any undesirables. Also includes the quality of traps set up, and the effectiveness of decoys.

    public int crafting = 500;//Determines quality and amount of resources used when crafting/constructing items.
                              //Eventually allows crafting of items of ever increasing complexity, such as turrets or some weapons.

    public int wit = 500;//Determines how much stress a character can take before breaking down and becoming useless. Also determines the speed of researching new options.
                         //Eventually allows ever fancier research, such as turrets.
}
