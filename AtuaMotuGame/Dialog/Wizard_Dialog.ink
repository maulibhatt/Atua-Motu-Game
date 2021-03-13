VAR accepted_quest = false
VAR has_items = false
VAR completed_quest = false
EXTERNAL giveItems(count)

Erised: Just the explorer I was waiting for.

 * [Need something?] You: You were waiting for me? What do you need?
 * [Why?] You: Why were you waiting for me?

- Erised: I need you to do an urgent quest for me right now. You need to go through this maze and find me a key.
 * [Accept] You: Okay, I will help you, but you need to answer some of my questions before I accept.
    Erised: I can answer all of your questions.
    -> main
 * [Decline] You: That doesn't sound appealing.
    Erised: You'll be back.
        ** [Leave] -> endpart

== main ==

* [Who are you] You: First, who are you?
    Erised: My name is Erised. I'm the island's most trusted Wizard. I have studied the magic of this island for many years.
    ** [Go Back] -> main
* [Key] You: Why is this key so important to find?
    Erised: It is meant as a sacrifice for Ochano. He was given a sacrifice before that satisfied him for centuries. This key is as old as his previous sacrifice was, so it'll be perfect.
    ** [Go Back] -> main
* [Why can't you] You: Why can't you go?
    Erised: Alex, you are the only human on the island. The rest of us are spirits hidden inside animals. Ochano already owns us, but you are free. You must be the one to go to him.
    ** [Go Back] -> main
* [Ochano] You: Tell me more about Ochano
    Erised: He will ask you who you are and what sacrifices you have to give. You must give him an answer that appeases him, or the whole island will be doomed.
   ** [Go Back] -> main
+ [Begin Quest] You: Okay, I accept the quest. I'll go now. -> quest

== quest == 
~ accepted_quest = true
Erised: Don't give up now! The island's fate is in your hands. Find that key.
 + [Keep looking] You: I'll look around.
    Erised: Good luck. -> endpart

== other_quest_active ==
Erised: Looks like you're busy with something else. You have to come back when you're done. I need your help. -> endpart

== after_quest ==
~ accepted_quest = false
~ has_items =  false
~ completed_quest = true
Erised: Congratulations on completing your quest.
 + [Leave] ->endpart
        
    
== endpart ==
    + [Exit] -> END