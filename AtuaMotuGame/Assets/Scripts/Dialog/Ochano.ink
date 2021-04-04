VAR good = 0
VAR neutral = 0
VAR bad = 0

Ochano: WHO DARES DISTURBS MY SLUMBER?
* [Great hero] You: I am Alex, great hero of Atua Motu. Enemy of anyone who disturbs its peace! 
    ~ good = good + 1
    -> q2
* [Humble servant] You: I am Alex, your humble servant. Please accept my service.
    ~ bad = bad + 1
    -> q2
* [Say nothing] You: ...
    ~ neutral = neutral + 1
    Ochano: DO NOT WASTE MY TIME WITH YOUR SILENCE, FOOL. 
    -> q2
* [You first] You: Give me your name and I shall give you mine.
    Ochano: HOW DARE YOU TURN IT AROUND ON ME? I WILL SMITE YOU.
    - You fail in your mission, and Ochano kills you. - ->END

== q2 ==
Ochano: IF YOU CAN SOLVE MY RIDDLE, I WILL ENTERTAIN YOU.
Ochano: 
-> END