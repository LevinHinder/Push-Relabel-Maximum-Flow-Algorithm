# Introduction
This program simulates the maximum flow through a network with the [push-relabel maximum flow algorithm](https://en.wikipedia.org/wiki/Push%E2%80%93relabel_maximum_flow_algorithm).


# Theory
If you want to learn more about this algorithm, I recommend to read the [Wikipedia article](https://en.wikipedia.org/wiki/Push%E2%80%93relabel_maximum_flow_algorithm). In addition, I have created a [Power Point](https://github.com/LevinHinder/Push-Relabel-Maximum-Flow-Algorithm/blob/main/push%E2%80%93relabel%20maximum%20flow%20algorithm.pptx) with a step by step example.


# Manual
1. Download the most recent [release](https://github.com/LevinHinder/Push-Relabel-Maximum-Flow-Algorithm/releases) or, clone the whole repository.
2. Run *Maximum_Flow.exe*
3. Create your custom network. To do so, select in the top left corner the element you want to place. Note: you need at least one start and one end node. By clicking on the screen, you can place your desired element. You can rearrange by drag and drop or delete by selecting the element and pressing the `delete` key.
   <p><img src="https://github.com/LevinHinder/Push-Relabel-Maximum-Flow-Algorithm/blob/main/images/manual%201.gif"/></p>
4. In the next step you can create eges by clicking on one and then on a second node. The direction of the edge is indicated by the arrow and is alwas from the first to the second node. Note that it is not possible for an edge to flow into a start node or out of an end node. You can delete an edge by selecting it and pressing the `delete` key.
    <p><img src="https://github.com/LevinHinder/Push-Relabel-Maximum-Flow-Algorithm/blob/main/images/manual%202.gif"/></p>
5. If desired you can modify the maximum capacity of an endge by selecting the edge and click on `edit` or double click in the table. A new menu will pup in the lower right corner. Alter the flow rate to your needs and confirm by hitting the `enter` key or by clicking on `save`. The edges will automaticly adjust their thickness according to their flow rate. To disable this feature, put the blue slider in the top left corner to the far left.
    <p><img src="https://github.com/LevinHinder/Push-Relabel-Maximum-Flow-Algorithm/blob/main/images/manual%203.gif"/></p>
6. You can also select a node and see all edges flowing either into or out of the node. By selecting the edges in the table, they will get marked in the flow network. The flow rate of edges can also be modified when being selected this way.
    <p><img src="https://github.com/LevinHinder/Push-Relabel-Maximum-Flow-Algorithm/blob/main/images/manual%204.gif"/></p>
7. Once you are happy with your flow network, you can simulate the maximum flow. Hit therefore the `simulate` button. The edges will now adjust their colour according to their load. Green means that the edge is not loaded, red that it is fully loaded and the colours in between indicate that it is partially loaded. You can check the excact load by selecting an edge and read the *current flow* from the table.
    <p><img src="https://github.com/LevinHinder/Push-Relabel-Maximum-Flow-Algorithm/blob/main/images/manual%205.gif"/></p>
8. After the simulation, you can still make modifications to your flow network and simulate it over again. Experiment with it! There is no limitation.
9. To delete all nodes and edges, hit the `clear` button in the bottom right corner.


# Bugs
This was one of my first big project in C# and it is therefore no wonder that there are some bugs in the code. Note: I do NOT intend to fix them as this would be far too time-consuming because I have done this projects years ago. I am more than happy however, if report or even fix some of the bugs.

## Known Bugs
- After the simulation, the flow rate of edges can no longer be made smaller than the current flow.
- Edges can not be deleted after simulation. They must first be moved and can only then be removed.
- ...


# License

    MIT License

    Copyright (c) 2022 Levin Hinder

    Permission is hereby granted, free of charge, to any person obtaining a copy
    of this software and associated documentation files (the "Software"), to deal
    in the Software without restriction, including without limitation the rights
    to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
    copies of the Software, and to permit persons to whom the Software is
    furnished to do so, subject to the following conditions:

    The above copyright notice and this permission notice shall be included in all
    copies or substantial portions of the Software.

    THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
    IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
    FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
    AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
    LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
    OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
    SOFTWARE.
