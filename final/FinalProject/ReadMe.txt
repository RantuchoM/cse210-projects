Final Project
--------------------
Martín Rantucho

When the program runs, it loads all the current information of people, ensemble and events from .txt files. 
All these things happen in Program.cs and then an AgendaManager class is created.
This class is in charge of handling the menu in loop to create different kinds of concerts and different kinds of rehearsals (which are associated with priorly created concerts).
It also allows to display all the events or only the ones associated with a concert. In both cases, it offers an option to edit that can modify some of the attributes with getters.
Even though there are three types of concerts and two types of rehearsals, all the events displayed and modified commonly thanks to a superclass that surrounds the Concert and Rehearsal superclasses, called AnyEvent.
When a concert is deleted, all the rehearsals associated with them are also deleted; because they're stored in a list of rehearsals.
There is more detail on how the four concepts of this program are implemented in the Articulate Assignment https://webmailbyui-my.sharepoint.com/:w:/g/personal/u285974517_byui_edu/EUMY43mcdIRLtEBFpk55V00Bue4V7xHZV995tR64HIwc0Q?e=nlaaci

The last option of the menu is to show the data about the ensembles, this is just for preview. Handling ensembles and their integrants are beyond the scope of this assignment, and are meant to be further developed with also a visual interface.
