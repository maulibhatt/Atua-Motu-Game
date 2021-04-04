VAR accepted_quest = false
VAR has_items = false
VAR completed_quest = false

VAR trout = false
VAR bones = false
VAR erised = false
VAR birch = false

EXTERNAL giveItems(count)

Ochano: Who is this tiny human that disturbs my slumber?

* [Alex] You: My name is Alex...
    -> why0
* {trout == true} [Assertive] You: I am this Island's hero, Alex.
    -> why1
* {birch == true} [Humble] You: I am Alex, oh great Ochano. Your humble servant.
    -> why0

== why0 ==
Ochano: Muahahaha! Alex, is it? What do you want?
* [Not sure] You: I'm not sure...
    -> anger_ochano
    
* {trout == true} [Free All Spirits] You: I want you to free all of the spirits that you've trapped on this island.
    -> what0

* {bones == true} [Free All Humans] You: I want you to free the human spirits that you've trapped on this island.
    -> what1
    
* {erised == true} [Appease Ochano] You: I am here to appease you, dear Ochano.
    -> sacrifice_yourself

== why1 ==
Ochano: Very well, hero. I applaud your bravery. What do you want?

* [Not sure] You: I'm not sure...
    -> amuse_ochano
* {trout == true}[Free All Spirits] 
    I want you to free all the spirits that you've trapped on this island.
    -> what0
* {bones == true} [Free All Humans] You: I want you to free the human spirits that you've trapped on this island.
    -> what1
* {erised == true} [Appease Ochano] You: I was told by a great wizard to appease you.
    -> sacrifice_yourself

== anger_ochano ==
Ochano: How dare you waste my time. I knew I should have destroyed this island a century ago... I guess it's not too late.

OCHANO DESTROYS THE ISLAND.
-> endpart

== what0 ==
Ochano: Freeing spirits requires a sacrifice. What will you give me?

* [Nothing] You: Ochano, I have nothing to give you, but you must free the spirits.
    -> sacrifice_yourself
* {bones == true} [Necklace] You: I have this bone necklace that meant a lot to someone.
    -> free_all
* {erised == true} [Key] You: I have this key, which is as old as your favourite sacrifice.
    -> old_sacrifice

== what1 ==
Ochano: Freeing spirits requires a sacrifice. What will you give me?

* [Nothing] You: Ochano, I have nothing to give you, but you must free the spirits.
    -> sacrifice_yourself
* {bones == true} [Necklace] You: I have this bone necklace that meant a lot to someone.
    -> free_humans
* {erised == true} [Key] You: I have this key, which is as old as your favourite sacrifice.
    -> old_sacrifice
    
== sacrifice_yourself ==
Ochano: Very well. You're the perfect sacrifice to appease me.

OCHANO KILLS YOU.
-> endpart

== amuse_ochano ==
Ochano: Very funny, Alex. You don't sound like you're ready to talk with me yet.

OCHANO DOES NOTHING.
-> endpart

== free_all ==
Ochano: Very wonderful sacrifice. This did mean a lot to its previous owner. Thus, I shall do as you requested. ALL the island spirits are free.

OCHANO FREES BOTH THE HUMAN AND THE EVIL SPIRITS.
-> endpart

== free_humans ==
Ochano: Very wonderful sacrifice. This did mean a lot to its previous owner. Thus, I shall do as you requested. The human spirits living on the island shall be freed.

OCHANO FREES THE TRAPPED HUMAN SPIRITS.
->endpart

== old_sacrifice ==
Ochano: Ah, you fool. The age of the sacrifice is not what makes it precious to me. But your words remind me of an old friend I must visit...

OCHANO RETURNS TO ATUA MOTU. 
-> endpart
    
== endpart ==
    + [Try Again] -> END