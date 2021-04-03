VAR accepted_quest = false
VAR has_items = false
VAR completed_quest = false
EXTERNAL giveItems(count)

Trout: Oh hello there sailor! Mind doing me a favour?

* [Yes] You: Sure. What do you need?
    -> accepted
* [No] You: No, not right now.
    -> declined

== accepted ==
~ accepted_quest = true
Trout: Can you catch 10 blue fish and bring them to me? -> questions

== questions ==
* {has_items == true} [Give fish] You: Here you go!
    ~giveItems(10)
    Trout: Perfect! 
    -> after_quest
    
* [How to catch] You: How do I catch the fish?
    Trout: The water is fairly shallow near the beach. 
    Trout: If you wade through, you'll be able to catch the fish. -> questions

+ [Leave] You: Okay, I'll try to catch them for you. -> END

== declined == 
Trout: Alright, come back when you can. -> endpart

== after_quest ==
~ completed_quest = true
~ has_items = false
~ accepted_quest = false

Trout: Thank you for catching those blue fish for me! -> info

== info ==

* [Ask for advice] You: Do you have any advice for me?
    Trout: I assume you mean related to your encounter with Ochano.
    Trout: Let me tell you something - Ochano has quite the temper. 
    Trout: If he gets angry and wants to destroy something, you might want to direct his anger to the volcano.
    Trout: Setting lava on fire won't harm the surrounding area. -> info

+ [Leave] You: Okay, bye now. -> END


== endpart ==
+ [Leave] You: Okay, bye! -> END