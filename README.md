# SolastaDruidClass

Mod to add Druid (with SRD circle of land) to Solasta. It's more jury-rigged/jank than most because of wildshapes so it's possible to slightly abuse/unbalance so that's for the player to limit rather than the mod.

Think of it as a intermediate beta version of the druid class until somebody more competent gets around to it.

There's 3 circles, Land, and two homebrew Circle of Spirit Shifting (Shifters) and Circle of Rift Wanderers (Wanderers). Shifters get melee boosts as an alternative to wildshapes and is mechanically a mix between Moon and Stars subclass. Wanderer gets a spirit that focuses on movement and is mechanically similar to the Wildfire subclass (which  focuses on fire) with a bit of the features of Stars subclass at higher levels.

Added produce flame cantrip. Might add some form of shillelagh or heat metal later if I can make them functional

**********************
Jury rigging/jank explained: 

Wildshape currently works by summoning a monster and banishing/(hidden and invincible) the caster rather than transforming the caster, and dismissing the summon reverses the process. The actions of the caster are limited while wildshaped to maintain the action economy of a single character. Consequently damage doesn't transfer over when the beast runs out of HP and the positions of the banished caster and summoned monster don't stay together. Caster is prevented from casting while wildshape is active until level 18.

Ideally the casters powers would also be prevented during wildshape to prevent abuse/unbalancing but you need to have a method to dismiss on command rather than waiting for the wildshape to expire. The proper way to do it would be do prevent both powers and casting while adding a unique action but that requires patching, which is better left to others.

The limited number of wildshape options are due to the limited number of beasts in the game that meet the CR and mobility requirements. Black and brown bear options will be turned on when the Devs add the models as they are currently using the orge model as a stand-in.

The wolf option is replaced by the Direwolf option to keep things tidy and I didn't think many would choose the weaker version when the stronger option becomes available
Homebrew subclass features are a mix and match of official subclass features that might result in unbalanced combat. Circle of land is in line with official specs.

******************

Might end up reworking wildshapes to work not via summons but via changing presentations / conditions (that grant temp hp and add monster attacks) so it is actually the caster on the frontline or even via proxy (seems less likely). Manipulation of character and monster presentations would be needed and I'm not sure they are compatible. The `forcedbeard` of belt of dwarvenkind and `featuredefinitioncharacterpresentation` could be a template to follow. it would require `rulesetcharacterhero` patch but it should be possible for people more comfortable with patching. `interruptionDamageThreshold` might be key for ending wildshape if using condition based approach

Any help or advice would be appreciated. 
