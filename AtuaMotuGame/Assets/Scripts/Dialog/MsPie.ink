VAR accepted_quest = false
VAR has_items = true
VAR completed_quest = false
EXTERNAL giveItems(count)

Ms. Pie: Hey there, Alex! Good of you to come around. Do you have time to help me with something?

* [Yes] You: Yes, what do you need me to do?
    -> accepted
* [No] You: No, but maybe later.
    -> declined

== accepted ==
~ accepted_quest = true

Ms. Pie: Can you find me 6 apples? I'm going to make some custard in the meantime. -> questions

== questions ==

* {has_items == true} [Give Apples] You: Here you go!
    ~giveItems(6)
    Ms. Pie: These are perfect!
    -> after_quest

* [Ask why] You: Why do you need apples?
    Ms.Pie: I'm making a dessert for my friend, Maple. She loves Apple tarts!
    -> questions
    
* [More info about quest] You: Can you tell me where I might find them?
    Ms. Pie: They'll be somewhere around the town. Some of them might be easier to find than others.
    Ms. Pie: It'll help to explore the area. Check out The Inn and visit the trees south of Paddle lake. 
    -> questions
+ [Leave] You: Okay, I'll look around. -> END


== declined ==
Ms. Pie: Alright, come back when you can! -> endpart

== after_quest ==
Ms. Pie: These will make perfect tarts. Thanks for getting me those apples. -> info

== info ==

* [Ask for advice] You: No problem! Can you help me understand what's going on in Atua Motu?
    Ms. Pie: Hmmm...
    Ms. Pie: I will tell you this - be careful about who you trust. Not everyone is what they seem.
    Ms. Pie: You may meet someone named Erised, who definitely can't be trusted.
    Ms. Pie: Some folks are trying to guide you towards destruction, and you will need to ...
    Ms. Pie: ... make some very difficult but important decisions.
    -> info

+ [Leave] You: I'll talk to you later! Goodbye. -> END

== endpart ==
    + [Exit] You: Goodbye! -> END
