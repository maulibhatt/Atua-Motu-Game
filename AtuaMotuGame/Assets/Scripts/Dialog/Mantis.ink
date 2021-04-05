VAR accepted_quest = false
VAR has_items = false
VAR completed_quest = false
EXTERNAL giveItems(count)

Mantis: Alex!! I need you to do some pest control for me. Are you free?

* [Yes] You: Sure! What do you need?
    -> accepted
* [No] You: No, not right now.
    -> declined

== accepted ==
~ accepted_quest = true

Mantis: You need to kill these blue Bunny Beetles and retrieve the carrots they've stolen. -> questions

== questions ==

* {has_items == true} [Give Carrots] You: I got all of the carrots!
    Mantis: Fantastic! 
    ~giveItems(12)
    -> after_quest

* [How?] You: How do I kill them?
    Mantis: You can attack them with your sword to kill them. 
    Mantis: Be careful though! They are quite fast and very protective of their carrots. -> questions

+ [Leave] You: Okay, I'll do my best. -> END

== declined ==
Mantis: Well, hopefully the situation doesn't get worse by the time you come back. -> endpart

== after_quest ==
~ completed_quest = true
~ has_items = false
~ accepted_quest = false

Mantis: The carrots you saved from the Bunny Beetles will feed my brother, Trout, and I for weeks! -> info

== info ==

* [Ask for advice] You: Do you have any advice for me?
    Mantis: When you meet the great fire spirit, Ochano, be humble.
    Mantis: Humility will make it easier for Ochano to trust you. -> info

+ [Leave] You: Okay, I'll talk to you later! -> END

== endpart ==
+ [Exit] You: I have to go now. Goodbye. -> END
