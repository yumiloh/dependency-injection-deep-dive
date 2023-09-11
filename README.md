# Dependency Injection  Deep Dive

## Introduction

Welcome to the Dependency Injection Deep Dive series!

In this series I will attempt to explain how .NET dependency injection works from ground up. Perhaps you have heard of DI, but not quite sure what exactly it is. Dependency injection itself already sounds fancy; sprinkle around a few more terms like service provider, service collection, singleton, scoped, or transient, and they will be floating around a newbie's head in confusion, not knowing what exactly they are and what exactly they do. Everything looks like magic. The explanation usually goes something like this: You don't want to create the dependencies yourself, so all you need to do is to _register_ the dependencies and the _container_ will resolve the dependencies you asked for and handle everything else. 

Regarding this topic, usually the more explanation is provided, the more confused I became. Okay, so actually we are using _service collection_ to register the dependencies, and some _service provider_ will _resolve_ them, returning the instances from somewhere. The ether, possibly ;) Then, it gets _injected_ into the constructor, and we are doing this to _decouple_ the implementation.

Service collection? I've never seen that anywhere. All I see is just `builder.Services.AddSingleton()`, apparently that's how we should register it? After that it will somehow automatically be _injected_ into the constructor? Those were just the tip of the confusion I had in the beginning. If you are facing similar woes, I hope this series will provide more clarity.

A lot of rudimentary concepts in programming can be explained in simple and plain language, but whenever dependency injection enters the conversation, suddenly all the terms surrounding it become ✨so fancy✨ at least that's what I thought when I first got acquainted with it as a junior. When I first heard of DI, I was wow-ed by its name. _Dependency injection_, huh? Gives a good roll of the tongue and make me sound knowledgeable, but in reality I knew nothing about it 🤣

Hopefully this series will demystify DI at the end and make this topic clear as day the next time you think of it ;) 




