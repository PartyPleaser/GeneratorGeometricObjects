# GeneratorGeometricObjects
GeneratorGeometricObjects library has been developed with two generators (Points Generator and Segments Generator). Main point is geometric objects should locate evenly inside square.
Generators contains two options:
1) Count of objects
2) Size of the square 
To get evenly locate objects we split the square to rectangles with next algorithm. 
First devide the square vertically in two half and then by horizontal if need it. Find out how many we made vertical and horizontal lines. After that find out how many we need additional split. Every next of these split should be in different quarter of the square. Use 'Shift By Y' and 'Shift By X' to get this.

Possible future library development:
1. We can easy add new kinds of generators
2. We don't have check that two point can be the same. If param 'count of object' very big and param 'size' very small and geometric object contain many point - we can get this
3. We can make another spliter algorithm and parametrize choice of spliter
4. We can create more unit tests (for RectangleSpliter as example)
