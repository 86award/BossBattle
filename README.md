# C# Player's Guide - Final Boss Battle
This repo is for recording my attempt at the Final Boss Battle in RB Whitaker's C# developer guide. The final coding project from the book is spread across 18 individual challenges, culminating a turn-based RPG. As with any battler, two parties, one consisting of friendly adventurers, the other made up by the forces of evil, will take turns attacking until one party's hit points are depleted/all characters defeated. Each character will be represented with unique characteristics and a range of attacks. Enemies will be varied with the last boss, The Uncoded One, presenting the final challenging round.

The book suggests all challenges are undertaken in/delivered via the Console. However, for a personal challenge, I wanted to build the project in Unity and present the project with a polished GUI (whilst still meeting all of the objectives/specification).

The final game will be able to be played with 1 player (vs. CPU) or 2 players.

## Current Challenge: The True Programmer
### Objectives
+ Allow player to enter a custom name for their character

## Challenge #1: Building Character
### Learnings
+ Structuring a Unity project is very different from a pure C# Console project. Whereas a Console project may rely on extensive inheritance, Unity doesn't lend itself to that way of working. Instead I've found myself building classes that then data driven by Scriptable Objects (SO).
+ Good learning about the structure of the project. The SOs are 'design-time entities' that hold the data and pass this to run-time classes doing the work e.g. BattleManager class. There is a chain of classes at work from GameManager -> BattleManager -> PartyManager -> Character.
+ I'm trying to keep everything loosely coupled i.e., non-owning classes don't need to know anything about how other classes work, just that they can work with the data they're supplied.
### Objectives
+ Game loop that supports two parties (heroes vs monsters)
+ Each battle round every character will get to take one action, alternating between parties
+ For this challenge, each party has one skeleton
+ Skeleton represented with nameplate
+ Communicate whose turn it is to the player
+ Support single action of 'do nothing'
+ The game will run automatically given there's no active actions to take
+ [Stretch] Arguably necessary - add a time limit to take action before default action is taken
### State of the project at the end of this challenge:
<img width="1236" height="589" alt="image" src="https://github.com/user-attachments/assets/1f9fa899-a160-4fad-b33a-47cd16d8f8bd" />
