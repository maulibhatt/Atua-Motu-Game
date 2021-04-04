VAR accepted_quest = false
VAR has_items = false
VAR completed_quest = false
EXTERNAL giveItems(count)

Erised: Hey there, Alex.

* [You look tired] You: You look tired, Erised. Are you alright?
    Erised: I am tired. I've been looking for the perfect metal to break through these violet stones.
    Erised: Would you like to help me out?
        ** [Yes] You: Sure! What would you like me to do?
            -> accepted
        ** [No] You: No, but good luck! 
            -> declined
+ [Leave] You: Hey Erised. Sorry, I've got to run. -> END

== accepted ==
~ accepted_quest = true
Erised: I need you to find me 8 blue gems. -> questions

== questions == 

* {has_items == true} [Give blue gems] You: Here you go!
    ~giveItems(8)
    Erised: These are perfect.
    -> after_quest
    
* [Why me] You: I'm flattered that you asked me, but what makes you think I can help?
    Erised: Your sword, of course! My pickaxe is made of iron, which doesn't budge the violet stones at all.
    Erised: You, on the other hand, have a silver sword.
    Erised: When silver makes contact with the violet stones, it become soft enough to break. ->questions

* [How] You: How do I find the blue gems?
    Erised: You can slash at the violet stones with your sword to break through them. 
    Erised: Some of the violet stones will have blue gems behind them.
    Erised: Be careful, though. I expect this is a fairly tiring job. 
    Erised: After you dig through 15 violet stones, I want you to take some rest and come back tomorrow. -> questions

* [Why blue gems] You: Why do you need blue gems?
    Erised: I find that the worst things around this island are blue.
    Erised: The colour blue renews my purpose. It reminds me of why I am here.
    Erised: I am going to melt these gems with some of my red gems and create a beautiful lavender stone.
    Erised: We don't get a lot of lavender-coloured jewelery here. I'm sure the island will love it. -> questions
    
+ [Leave] You: Alright, I'm off hunting for those gems! -> END

== declined ==
Erised: Alright. See you around, Alex. -> endpart

== after_quest ==
~ completed_quest = true
~ has_items = false
~ accepted_quest = false

Erised: These gems will make wonderful jewelery for the island! -> info

== info ==

* [Ask for advice] You: Do you have any advice for me?
    Erised: You mean for your meeting with Ochano? 
    Erised: The best advice I can give is INSERT RIDDLE ANSWER. -> info

+ [Leave] You: Alright, see you later! -> END

== endpart ==
+ [Leave] You: Bye! -> END

