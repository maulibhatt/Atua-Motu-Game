VAR good = 0
VAR neutral = 0
VAR bad = 0
VAR free = "both"
VAR strength = 5
Ochano: "WHO DARES DISTURB MY SLUMBER?"

* [Great hero] You: "I am Alex, great hero of Atua Motu. Enemy of anyone who disturbs its peace!"
    ~ good = good + 1
    -> q2
* [Humble servant] You: "I am Alex, your humble servant. Please accept my service."
    ~ bad = bad + 1
    -> q2
* [Say nothing] You: "..."
    ~ neutral = neutral + 1
    Ochano: "DO NOT WASTE MY TIME WITH YOUR SILENCE, FOOL."
    -> q2
* [You first] You: "Give me your name and I shall give you mine."
    Ochano: "HOW DARE YOU TURN IT AROUND ON ME? I WILL SMITE YOU."
    You fail in your mission, and Ochano kills you. ->END

== q2 ==
Ochano: "ANSWER MY RIDDLE AND I WILL ENTERTAIN YOU."
Ochano: "TOOTHLESS IT BITES, WEAPONLESS IT BRINGS DEATH AND DOOM."
Ochano: "LIKE ITS OPPOSITE IT CRACKS, BUT ITS PRESENCE CAN'T FILL A ROOM."
Ochano: "NOT THE BEGINNING OF THINGS, BUT SURELY THE END."
Ochano: "TELL ME ITS NAME, OR IN DARKNESS YOU'LL DESCEND."

* [Heart] You: "Is it the heart?"
    ~ neutral = neutral + 1
    Ochano: "HAHA! TYPICAL HUMAN. YOU AMUSE ME." 
    -> q3
* [Fire] You: "Is it fire?"
    ~ bad = bad + 1
    Ochano: "FEAR ME, DO YOU?"
    -> q3
    
* [Ice] You: "Is it ice?"
    ~ good = good + 1 
    Ochano: "VERY GOOD..."
    -> q3
    
* [Sword] You: "Is it my sword?"
    Ochano: "WELCOME THE DARKNESS, ALEX."
    You fail in your mission, and Ochano kills you. -> END

== q3 ==
Ochano: "WHAT IS YOUR PURPOSE?"

* [Activate temple crystal] You: "I want you to activate the sacred crystal on your temple."
    ~ free = "bad"
    -> q4
* [Release all spirits] You: "I want you to release all of the spirits on the island."
    ~ free = "both"
    -> q4
* [Resurrect the Guardian] You: "I want you to resurrect the old Guardian."
    ~ free = "good"
    -> q4
    
* [Ochano leaves Atua Motu] You: "I want you to leave Atua Motu."
    Ochano: "YOU FOOL. I WILL NEVER LEAVE ATUA MOTU."
    You are unsuccessful, but Ochano lets you live. -> END
    
== q4 ==
Ochano: "VERY WELL. I WILL GRANT YOU YOUR WISH, BUT IN EXCHANGE, I WANT YOU TO SACRIFICE A PART OF THE ISLAND."
Ochano: "WHAT SHOULD I SET ON FIRE?"

* [Town] You: "Set fire to the town."
    Ochano: "DAMN. THAT'S COLD... ATUA MOTU DOESN'T DESERVE YOU."
    Ochano kills you for being terrible. -> END
    
* [Beach] You: "Set fire to the beach."
    ~ neutral = neutral + 1
    
    -> q5
* [Ice caves] You: "Set fire to the ice caves."
    ~ good = good + 1
    ~ strength = 0
    -> q5
    
* [Volcano] You: "Set fire to the volcano."
    ~ bad = bad + 1 
    ~ strength = 10
    -> q5
    
== q5 == 

{ neutral > 1:
    -> neutral_end
    }

{ good > 1:
    -> good_end
    }
    
{ bad > 1:
    -> bad_end
    }

{ good == bad == neutral:
    -> neutral_end
    }
    

== neutral_end ==
{ strength > 5:
    You strengthened Ochano by adding fire to his fire source, the Volcano. 
    Ochano vows to set Atua Motu ablaze. 
    }

{ strength < 5:
    Ochano was weakened when you sent his fire into the ice caves. 
    The fire melted the paradise for all to enjoy.
    }
    
{ strength == 5: 
    The sand heats up, and some of the water from the beach evaporates. 
    Nothing else changes. You live, but the spirits are still trapped.
    }
    
-> END

== good_end ==
Ochano: "I WILL FULFILL YOUR DEMANDS IF YOU AGREE TO STAY HERE, TRAPPED WITH ME FOR ETERNITY."
Ochano: "IF YOU WITHDRAW YOUR REQUEST, I WILL SET YOU FREE."

* {free == "bad"} [Activate temple crystal] You: "I want you to activate the sacred crystal on the temple."
    Ochano: "VERY WELL. IT IS DONE."
    Ochano frees his evil followers into the world, where they wreak havoc on more than just Atua Motu.
    You stay trapped on the island with the human spirits and Ochano.
    {strength < 5:
        On the bright side, the ice caves have melted back into the paradise.
        You and the human spirits can spend your days with an island oasis nearby.
        }
    -> END
    
* {free == "both"} [Release all spirits] You: "I want you to release all of the spirits on the island."
    Ochano: "VERY WELL. IT IS DONE."
    Ochano traps you on the island forever, but he frees all spirits into the world. 
    His evil spirit followers wreak havoc, but the trapped humans spirits are finally free. -> END
    
* {free == "good"} [Resurrect the Guardian] You: "I want you to resurrect the old Guardian."
    OCHANO: "VERY WELL. IT IS DONE."
    Ochano resurrects the old Guardian of Atua Motu. 
    They battle, and Ochano is banished from the island along with his evil followers. 
    The trapped human spirits are set free, and Atua Motu is protected once more. -> END
    
* [Escape Atua Motu] You: "I want to escape Atua Motu."
    Ochano: "VERY WELL. IT IS DONE."
    Ochano frees you from Atua Motu but keeps all of the other spirits trapped and under his rule. -> END
    
== bad_end ==
Ochano: "I WILL FULFILL YOUR DEMANDS IF YOU OFFER YOURSELF AS SACRIFICE."
Ochano: "IF YOU DON'T, I WILL TAKE EVERY SPIRIT ON ATUA MOTU AS SACRIFICE INSTEAD."

* [Sacrifice yourself] You: "I will sacrifice myself."
    {free == "bad" and strength < 5:
    Ochano kills you and frees his evil followers into the world where they can wreak havoc. 
    On the bright side, the trapped human spirits can enjoy the paradise that Ochano melted with his fire.
    }
    {free == "bad" and strength > 5:
    Ochano kills you and frees his evil followers into the world where they can wreak havoc. 
    Unfortunately, Ochano's power has increased and the trapped human spirits are tortured by him at every opportunity.
    }
    {free == "bad" and strength == 5:
    Ochano kills you and frees his evil followers into the world where they can wreak havoc. 
    The trapped human spirits are still under Ochano's rule.
    }
    {free == "good" and strength < 5:
    Ochano kills you but resurrects the guardian. 
    Ochano's fire energy has been weakened by the ice from the caves, so he loses the battle when the Guardian challenges him again.
    You are dead but Atua Motu's spirits are free at last.
    }
    {free == "good" and strength > 5:
    Ochano kills you but resurrects the old Guardian. 
    Ochano's fire energy has been strengthened by the volcano, so he wins when he is challenged by the Guadian again.
    Ochano punishes the island by engulfing it in flames for a century.
    }
    {free == "good" and strength == 5:
    Ochano kills you but resurrects the Guardian. 
    Ochano and the Guardian fight to the death, both destroying each other in the process.
    Without Ochano, the trapped spirits are free...
    But his evil followers still haunt Atua Motu and Ochano resumes his slumber.
    }
    {free == "both":
    Ochano kills you but frees all of the spirits. 
    The spirits that used to be his evil followers wreak havoc on the rest of the world, but the trapped human spirits are finally free.
    }
    -> END
    

* [Sacrifice the spirits] You: "Take the spirits, but please spare me!"
    Ochano: "YOU ARE A COWARD. I WILL NOT KILL YOU, BUT YOU WILL NEVER LEAVE ATUA MOTU."
    Ochano destroys all of the spirits on the island except for you. You wander the barren land with no one but Ochano for company until the end of time.


-> END