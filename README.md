# Conway's Game of Life

This is an implementation of John Conway's famous "Game of Life," showcasing the development of cellular automation on a square grid.

## Project Description

In this project, you can customize the size of the grid where cells appear randomly. Once initialized, the cells evolve according to predefined rules. The game develops based on the initial configuration of cells, and you can observe how chaos turns into stable or cyclical patterns.

## Game Rules

1. **Survival:** Any live cell with two or three live neighbors survives to the next generation.
2. **Underpopulation:** Any live cell with fewer than two live neighbors dies due to underpopulation.
3. **Overpopulation:** Any live cell with more than three live neighbors dies due to overpopulation.
4. **Reproduction:** Any dead cell with exactly three live neighbors becomes a live cell, as if by reproduction.

## How It Works

1. **Grid Size:** You can specify the size of the grid, which affects the number of cells in the game.
2. **Random Initialization:** After choosing the size, cells are randomly placed on the grid.
3. **Evolution:** After each simulation step, cells change their state (alive or dead) based on the specified rules.

![image](https://github.com/user-attachments/assets/c300ab9d-2476-4ffa-b4b8-167beaefd0ea)
