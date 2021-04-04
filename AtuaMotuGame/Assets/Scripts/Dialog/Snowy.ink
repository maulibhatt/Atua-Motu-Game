VAR accepted_quest = false
VAR has_items = true
VAR completed_quest = true
EXTERNAL giveItems(count)

== after_quest == 
Snowy: Hey buddy! Good of you to come all this way to visit me. -> info

== info ==

* [Ask about Ochano] You: I want to learn more about Ochano and how to defeat him.
    Snowy: I can see why you'd want to know. Ochano and his followers have run this island for a long time.
    Snowy: But I doubt Ochano would be as powerful without his followers... -> info
    

* [How to visit again] You: Snowy... will I have to slide across all this ice to see you again? 
    Snowy: Of course not! You can use my ladder if you want to visit me again.
    Snowy: It goes under all of the ice, so it's much faster than sliding. -> info
    
+ [Leave] You: It was nice seeing you. Goodbye! -> END