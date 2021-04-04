VAR accepted_quest = false
VAR has_items = false
VAR completed_quest = false
EXTERNAL giveItems(count)

Igneous: Alex! Thank goodness you're here! I need your help ASAP!

* [Yes] You: Is everything okay? What do you need?
    -> accepted
* [No] You: Not right now.
    -> declined
    
== accepted ==
~ accepted_quest = true

Igneous: I need you to bring me the bone necklaces! -> questions
Igneous: I fear that this volcano will fall apart if we don't do something soon.

== questions ==

* {has_items == true} [Give bone necklaces] You: I got the necklaces!
    ~giveItems(3)
    Igneous: Alex! You just saved the day! 
    -> after_quest
    

* [What happened] You: What happened? How did the volcano get like this?
    Igneous: Well, I was practicing some of my wizardry and trying to learn how to make portals...
    Igneous: ... when I accidentally added too much ice to one of the ingredients, my bone necklaces.
    Igneous: I created some portals alright, but the necklaces spawned obsidian monsters!
    Igneous: On top of that, the portals only work one-way.
    Igneous: The portals trapped me here and trapped the obsidian monsters on the floating rock platforms. -> questions

* [What to do] You: What can I do?
    Igneous: The bone necklaces created the obsidian monsters. 
    Igneous: If you push them into the lava, there will be enough heat to neutralize the extra ice I added.
    Igneous: That should be enough to reverse the portal and teleport you and the necklace back.
    Igneous: Sadly, it'll destroy the portal in the process, but it's a risk we need to take.
    Igneous: Be sure to push them with your sword! They are too hot for you to touch.
    Igneous: I'll be watching you from this platform. If you do fall off, don't worry. 
    Igneous: I'll bring you back to the portal before you touch the lava, and you can try again. ->questions

+ [Leave] You: Okay. Keep me safe! -> END

== declined == 
Igneous: Okay, come back as soon as you can! I really need your help. -> endpart

== after_quest == 
~ completed_quest = true
~ has_items = false
~ accepted_quest = false

Igneous: Thank you for getting back my bone necklaces! -> info

== info ==

* [Ask for advice] You: Do you have any advice for me?
    Igneous: Good question. I want you to think about the task you helped me with today.
    Igneous: My advice is this - ice weakens fire. Be sure to keep that in mind.
    Igneous: Given that Ochano is the great fire spirit, I'm sure this advice will come in handy. -> info

* [Bone Necklaces] You: What do you plan to do with them now?
    Igneous: I think I will try to make portals again.
    Igneous: I want to eventually extend them to beyond this island.
    Igneous: Hopefully one day, I can help my friends escape. -> info

+ [Leave] You: Okay, bye for now. -> END

== endpart ==
+ [Leave] You: Okay, see you later. -> END

