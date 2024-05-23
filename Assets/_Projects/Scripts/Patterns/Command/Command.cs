using GPP;

[System.Serializable]
public abstract class Command
{
    /*
        * "A command is a reified method call."
        * 
        * “Commands are an object-oriented replacement for callbacks.”
        * 
        * meaning taking some concept and turning it into a piece of data — an object — that you can stick in a variable, pass to a function, etc.
        * So by saying the Command pattern is a “reified method call”, what I mean is that it’s a method call wrapped in an object.
        *
        * We can use this same command pattern as the interface between the AI engine and the actors; the AI code simply emits Command objects.
        * We can use different AI modules for different actors. Or we can mix and match AI for different kinds of behavior. Want a more aggressive opponent? Just
        * plug-in a more aggressive AI to generate commands for it. In fact, we can even bolt AI onto the player’s character, which can be useful for things like
        * demo mode where the game needs to run on auto-pilot.
        */
    public abstract void Execute(CommandActor actor);

    public abstract void Undo(CommandActor actor);
}

