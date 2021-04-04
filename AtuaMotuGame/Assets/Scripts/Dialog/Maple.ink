VAR accepted_quest = false
VAR has_items = false
VAR completed_quest = false
EXTERNAL giveItems(count)

Maple: Help! Help!
Maple: Oh thank goodness you're here! Can you help me find my sister?

* [Yes] You: Yeah, I can! 
    -> accepted
* [No] You: Not right now. 
    -> declined

== accepted ==
~ accepted_quest = true
{ has_items == true:
    Maple: Oh there you are Birch! Thank goodness you're okay. I was so worried. Stay here, okay?
    ~ giveItems(1) 
    -> after_quest 
    }
Maple: My little sister, Birch, wandered into the forest, and I think she's lost. 
Maple: I don't think she will be able to get out by herself. Even I have trouble finding my way around this maze of trees!

Maple: When you find her, let her know I sent you and she will follow you out.

Maple: The forest opens up at different points on this path where you can come out and find your way to me. 

->endpart

== declined ==
Maple: Come back when you can help me! Please hurry! -> endpart

== after_quest ==
~ completed_quest = true
~ has_items = false
~ accepted_quest = false
Maple: Thank you for finding my sister! Please let me know if I can do anything for you. -> info

== info ==

* [Ask for Advice] You: Can you give me some advice?
    Maple: Absolutely. After you finish 3 quests, you will be able to meet Ochano. You should approach him with confidence. He will respect you for it. -> info

+ [Leave] You: Okay, I have to go now. -> END

== endpart ==
    + [Leave] You: Okay, I have to go now. -> END
