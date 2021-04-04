VAR accepted_quest = true
VAR has_items = false
VAR completed_quest = false
EXTERNAL giveItems(count)

Frosty: Hey there, Alex. What's up? -> start

== accepted ==
Frosty: Hey there, Alex. What's up? -> start

== start ==

* [Ask about Ochano] You: I want to learn more about Ochano and how to defeat him.
    Frosty: Defeat him, eh? Snowy will probably know all about that. He lives just across the ice! -> info
    
* [Ask about ice] You: Why is there so much ice here?
    Frosty: This used to be the island's paradise, beloved be all...
    Frosty: But the island's old Guardian froze it before he was vanquished by Ochano.
    Frosty: Freezing the paradise the Guardian the chance to preserve its beauty from the wrath of Ochano.
    Frosty: Sadly, with no one to unfreeze it, it just serves as a reminder of what used to be. -> start

+ [Leave] You: I'll talk to you later. -> END

== info ==

* {has_items == true} [How to get across] You: How do I get across the frozen ice?
    Frosty: Snowy said he was happy you visited him, so he sent you a ladder for next time!
    ~giveItems(1)
    Frosty: You can visit him very quickly if you climb through. -> info
    

* {has_items == false} [How to get across] You: How do I get across the frozen ice?
    Frosty: It's easy enough if you know what you're doing.
    Frosty: Just remember, once you're on the ice, you won't be able to change directions until you stop.
    Frosty: Try to choose a direction that will lead to the exit of each lake. -> info

+ [Leave] You: Okay, goodbye Frosty! -> END
    