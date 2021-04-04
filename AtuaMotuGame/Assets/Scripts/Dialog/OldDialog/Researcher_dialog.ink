VAR accepted_quest = false
VAR has_items = false
VAR completed_quest = false
EXTERNAL giveItems(count)

Bones: Hey there Alex! How are you doing today?

 * [Good] You: I'm good. The sun is shining, the birds are chirping.
    Bones: That's great to hear! ->main
 * [Bad] You: I'm not doing too great. I feel pretty confused.
    Bones: Ah... what you're sensing is foreboding. Maybe talking with me will help you feel better. -> main



== main ==
Bones: Let me know if there's anything I can help you with.

* [Giant Skull] You: Can you tell me about that giant skull in the sand?
    Bones: That is a sad story, I'm afraid. Long ago, Atua Motu had a Guardian that kept its residents safe and happy. He was vanquished many centuries ago.
    ** [What happened?] A great fire spirit destroyed the guardian and imprisoned all of the island spirits.
        *** [Go Back] -> main
* [Who are you] You: I'm sorry, but who are you?
    Bones: My name is Bones. I'm the island's archeology and fossil researcher. You would not believe the things I've found on this island.
    ** [Go Back] -> main
+ [What are you doing] You: What are you doing right now?
    Bones: Well, I was looking for some ancient rings to learn about the magic that lives on this island. Would you like to help?
    ++ [Yes] You: Yes, of course! 
        Bones: Great! 
        -> quest
    ++ [No] You: No, not right now. 
        Bones: No problem.
        -> main
+ [Leave] You: Good luck, and thanks for talking with me. Bye! -> endpart

== quest == 
~ accepted_quest = true
Bones: I'm looking for a ring, with a single blue gemstone on it.
 * { has_items == true } [Give Ring] You: I found the ring you were looking for.
    ~ giveItems(1)
    Bones: Thank you for completing my quest! To say thanks, I want you to have something that's important to me. The bone on this necklace was the first I'd ever found.
    ** [Take necklace]
    -> after_quest
 + [Keep looking] You: I'll look around.
    Bones: Thanks Alex! -> endpart

== other_quest_active ==
Bones: Looks like you're busy with something else. Come talk to me when you're done. -> endpart

== after_quest ==
~ accepted_quest = false
~ has_items =  false
~ completed_quest = true
Bones: This ring looks amazing, and carries an energy that I'm excited to investigate. Thank you again, Alex. Let me tell you something.
 + [Continue]
    Bones: Our Guardian saved our spirits from being destroyed by sacrificing itself. The Guardian meant a lot to the island inhabitants, so Ochano was satisfied with the Guardian's sacrifice.
    ++ [Continue]
        Bones: But he will rise again, and when he does, you must be ready. 
        +++ [Continue]
            Bones: Be careful about who you trust. The island is full of spirits, many of whom are happy to be under Ochano's rule.
            ++++ [Leave] You: Thanks! I'll keep that in mind. ->endpart
        
    
== endpart ==
    + [Exit] -> END