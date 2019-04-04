The Dependency Inversion Principle is comprised of two rules:
+ High-level modules should not depend on low-level modules.  Both should depend on abstractions.
+ Abstractions should not depend on details.  Details should depend on abstractions.

This principle is primarily concerned with reducing dependencies among the code modules.  We can think of it as needing the low-level objects to define contracts that the high-level objects can use, without the high-level objects needing to care about the specific implementation the low-level objects provide.

Please note that the DIP is not quite the same thing as Dependency Injection.