VAR accepted_quest = false
VAR has_items = false
VAR completed_quest = false
EXTERNAL giveItems(count)


Birch: Hi there! Are you lost?

 * [No] You: No, I know my way around.
    Birch: Hah! You're one of the few.
 * [Yes] You: Yeah, a bit. This island is pretty big.
    Birch: It's definitely big enough for things to get lost around here.

-> main

== main ==
Birch: Okay good chat. Feel free to be on your way.

* [The Forest] You: There are so many trees around here.
    Birch: Yeah, the biodiversity is great! Being around the forest makes me feel like I'm being purified. I can almost smell the oxygen!
    ** [Go Back] -> main
* [Who are you] You: I'm sorry, but who are you?
    Birch: My name is Birch. I'm the island's forest ranger. It's my job to make sure these trees stay happy and alive. 
    ** [Go Back] -> main
+ [What are you doing] You: What are you doing on a nice day like this?
    Birch: I'm trying to collect some green apples for a new fertilizer that I'm making. Would you like to help?
    ++ [Yes] You: Yes, of course! 
        Birch: Great! 
        -> quest
    ++ [No] You: No, not right now. 
        Birch: That is a bummer.
        -> main
* [Talking animals] You: Um... If you're an animal, how can you talk to me?
    Birch: What, did you think humans were the only ones who had something to say? Atua Motu helps us talk. It has magic in its very soil.
    ** [Go Back] -> main
+ [Leave] You: Good luck, and thanks for talking with me. Bye! -> endpart

== quest == 
~ accepted_quest = true
Birch: I'm only 3 green apples away from making my tree fertilizer. If you can find them for me, I'd be very grateful.
 * { has_items == true } [Give Apples] You: I found 3 apples for you, Birch. 
    ~ giveItems(2)
    Birch: Thank you for completing my quest!-> after_quest
 + [Keep looking] You: I'll look around.
    Birch: Thanks champ! -> endpart

== other_quest_active ==
Birch: Looks like you're busy with something else. Come talk to me when you're done. -> endpart

== after_quest ==
~ accepted_quest = false
~ has_items =  false
~ completed_quest = true
Birch: The trees will thank you for all that you've done for me. For payment, I'll give you a bit of advice. 
 + [Continue]
    Birch: You have a great trial coming your way, Alex. How you choose to approach that perilous trial will decide the entire fate of the island.
    ++ [Continue]
        Birch: Atua Motu's wizard will give you something you're really going to need when you see Ochano. Trust him.
        +++ [Continue]
            Trout: When you do come face-to-face with Ochano, remember to be humble. He is capable of much destruction, and it's best to stay on his good side.
            ++++ [Leave] You: Thanks! I'll keep that in mind. ->endpart
        
    
== endpart ==
    + [Exit] -> END