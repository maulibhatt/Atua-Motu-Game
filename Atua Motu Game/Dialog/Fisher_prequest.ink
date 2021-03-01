VAR accepted_quest = false

Trout: Hello Alex! It's about time you came around.

 * [Waiting for me?] You: Were you waiting for me?
 * [What do you mean?] You: "About time"? What do you mean?

- Trout: The whole island has been waiting for you to arrive. 

-> main

== main ==
Trout: If those are all your questions, I'm going to continue on with my work.

* [The Beach] You: What a nice beach. Is this where you live?
    Trout: Yes. It used to be a nice beach. Now it's just a ruin full of rocks, dirt, and a receding shoreline. 
    ** [Go Back] -> main
* [Who are you] You: I'm sorry, but who are you?
    Trout: I am the island's fisher, Trout. I am responsible for the entire island's supply of fish.
    ** [Go Back] -> main
+ [About the work] You: Can I help you with your work?
    Trout: Seeing as you are not a fisher, you won't be able to do much for me. Still, I could use your help. I've lost my fishing gloves, and without them, I can't fish. Can you help me find them?
    ++ [Yes] You: Yes, of course! 
        Trout: Great! 
        -> quest
    ++ [No] You: No, not right now. 
        Trout: That's too bad. 
        -> main
* [The Island] You: Can you tell me about this island?
    Trout: The name of this Island is Atua Motu. It is full of many mysteries. Atua Motu is run by the effort of all the animals that live here. 
    ** [Go Back] -> main

+ [Leave] You: Good luck, and thanks for talking with me. Bye! -> endpart

== quest == 
~ accepted_quest = true
Trout: I think I left my fishing gloves somewhere around the beach. Please hurry! I need them to fish.
+ [Okay]
    -> END
    
== endpart ==
    + [Exit] -> END