VAR accepted_quest = false
VAR has_items = false
VAR completed_quest = false
EXTERNAL giveItems(count)

Bones: Hey there Alex! 

* [What are you doing] You: Hey Bones! What are you up to? 
    Bones: I'm trying to find an ancient tablet using this scroll. Want to help?
        ** [Yes] You: Sure!
            -> accepted
        ** [No] You: No, not right now
            -> declined
+ [Leave] You: Sorry Bones, I'll talk to you later. -> END

== accepted ==
~ accepted_quest = true
Bones: There's a riddle on this scroll that will help you find the tablet.
Bones: "Once I had thoughts, but now I'm white and empty. 
Bones: You will find the treasure under a cactus south of me.
Bones: I am a small paradise surrounded by dryness and heat.
Bones: You will find the treasure east of me. " -> questions

== questions ==

* {has_items == true} [Give tablet] You: I found the tablet.
    ~giveItems(1)
    Bones: Great work, Alex! 
    -> after_quest

* [How to find it] You: How do I find the tablet?
    Bones: The riddle is supposed to help you find the right spot to dig.
    Bones: Press [SPACE] to dig.
    Bones: Don't dig willy nilly, though. The desert heat is very strong.
    Bones: You should preserve your energy and dig only in places you're sure about.
    Bones: I usually get tired after I dig in 20 places, so I expect you will too. 
    Bones: But don't worry, you can always come back and try again tomorrow. -> questions

+ [Leave] You: Okay, I'll get to digging. -> END


== declined == 
Bones: No problem. Talk to you later! -> endpart

== after_quest == 
~ completed_quest = true
~ has_items = false
~ accepted_quest = false
Bones: You did so well solving that riddle! I can't wait to examine this tablet. -> info

== info ==

* [Skull] You: Can you tell me about the giant skull in the middle of the desert?
    Bones: That is a sad story, I'm afraid. 
    Bones: Long ago, Atua Motu had a Guardian that kept its residents safe and happy.
    Bones: One the great fire spirit, Ochano, vanquished the Guardian and exposed Atua Motu to peril.
    Bones: Only when the Guardian is resurrected can Atua Motu's human spirits be freed. -> info

* [Atua Motu History] You: Can you tell me about the island?
    Bones: Sure! I'm sure you've noticed, but Atua Motu is a unique island with talking animals.
    Bones: We are actually spirits trapped in these bodies. 
    Bones: But, not all of us are trapped.
    Bones: There are also spirits that are Ochano's followers, and they are willingly here to lead you astray.
    ** [Which spirits] You: How can I tell which spirits are Ochano's followers and which are trapped human spirits?
        Bones: Every blue animal on this island is a human spirit.
        Bones: Some human spirits, like me, are seen as bears that can talk.
        Bones: Of course, many of Ochano's spirit followers disguise themselves to look like bears too. 
        Bones: You must be careful whose advice you take.-> info
  

+ [Leave] You: Okay, I'll talk to you later. -> END


== endpart ==
+ [Leave] You: Okay, bye! -> END