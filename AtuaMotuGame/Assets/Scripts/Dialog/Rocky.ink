VAR accepted_quest = false
VAR has_items = false
VAR completed_quest = false
EXTERNAL giveItems(count)

Rocky: Hey Alex.

* [Ask what's wrong] You: Rocky, you look a bit glum. Everything okay?
    Rocky: No. I left my favourite pair of rock climbing gloves at the top of this cliff. 
    Rocky: I want to get them back, but my other pair just fell apart.
    ** [Offer to help] You: I can get them for you!
        Rocky: That would be great! I feel so much better already!
        -> accepted
    ** [Leave] You: Sorry to hear that, Rocky. I'm a bit busy now, but I'll try to help you later. 
        -> declined
        
* [Leave] You: Hey Rocky. Gotta go. ->END

== accepted ==
~ accepted_quest = true
Rocky: My rock climbing gloves are at the top of this cliff. -> questions

== questions ==
* {has_items == true} [Give gloves] You: Actually, your gloves are right here!
    ~giveItems(2)
    Rocky: You found them! 
    -> after_quest

* [How to get them] You: How do I get them?
    Rocky: You need to climb up this cliff, but be careful!
    Rocky: It is an old cliff, so sometimes there are boulders that fall from the top.
    Rocky: Those boulders will bring you back to the bottom, so you need to maneuver away from them. -> questions
    
* [Is it safe?] You: Uh... Rocky, is this safe?
    Rocky: It's definitely not. Rock climbing takes a lot out of you.
    Rocky: I expect you will only have enough energy to climb up 3 times, so try not to get knocked down.
    Rocky: If you press up agaist the ledges, you'll be safe from falling boulders.
    Rocky: But if you get too tired, you can always rest and try again tomorrow! -> questions

+ [Leave]  You: Okay, I'll give it a shot. -> END

== declined == 
Rocky: No problem. -> endpart

== after_quest ==
~ completed_quest = true
~ has_items = false
~ accepted_quest = false
Rocky: Thank you so much for finding my favourite rock climbing gloves for me! -> info

== info ==

* [Ask for advice] You: Anytime! I'm nervous about meeting Ochano. Can you give me some advice?
    Rocky: Sure! Ochano is pretty vicious, but he loves riddles. 
    Rocky: He will probably tell you a variation of his favourite riddle. 
    Rocky: I don't remember all of it, but I do remember there was a part about the world ending in ice. 
    Rocky: Keep that in mind, and good luck! -> info
    
+ [Leave] You: See you later! -> END


== endpart ==
+ [Leave] You: Okay, bye! -> END
