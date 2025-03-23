using System;

public class Node
{
    public int Value;
    public Node Left, Right;

    public Node(int value)
    {
        Value = value;
        Left = Right = null;
    }
}

public class BinaryTree
{
    public Node Root;

    // Método para insertar un nodo en el árbol
    public void Insert(int value)
    {
        Root = InsertRecursive(Root, value);
    }

    private Node InsertRecursive(Node root, int value)
    {
        if (root == null)
            return new Node(value);

        if (value < root.Value)
            root.Left = InsertRecursive(root.Left, value);
        else
            root.Right = InsertRecursive(root.Right, value);

        return root;
    }

    // Método para eliminar un nodo del árbol
    public Node Delete(Node root, int value)
    {
        if (root == null) return root;

        if (value < root.Value)
            root.Left = Delete(root.Left, value);
        else if (value > root.Value)
            root.Right = Delete(root.Right, value);
        else
        {
            if (root.Left == null)
                return root.Right;
            else if (root.Right == null)
                return root.Left;

            root.Value = MinValue(root.Right);
            root.Right = Delete(root.Right, root.Value);
        }
        return root;
    }

    private int MinValue(Node root)
    {
        int minv = root.Value;
        while (root.Left != null)
        {
            minv = root.Left.Value;
            root = root.Left;
        }
        return minv;
    }

    // Método para recorrer el árbol en Pre-Orden (Root, Izquierda, Derecha)
    public void PreOrder(Node node)
    {
        if (node != null)
        {
            Console.Write(node.Value + " ");
            PreOrder(node.Left);
            PreOrder(node.Right);
        }
    }

    // Método para recorrer el árbol en In-Orden (Izquierda, Root, Derecha)
    public void InOrder(Node node)
    {
        if (node != null)
        {
            InOrder(node.Left);
            Console.Write(node.Value + " ");
            InOrder(node.Right);
        }
    }

    // Método para recorrer el árbol en Post-Orden (Izquierda, Derecha, Root)
    public void PostOrder(Node node)
    {
        if (node != null)
        {
            PostOrder(node.Left);
            PostOrder(node.Right);
            Console.Write(node.Value + " ");
        }
    }

    // Método para buscar un valor en el árbol
    public Node Search(Node root, int value)
    {
        if (root == null || root.Value == value)
            return root;

        if (value < root.Value)
            return Search(root.Left, value);
        else
            return Search(root.Right, value);
    }

    // Método para imprimir la ruta de búsqueda de un valor
    public void PrintSearchPath(Node root, int value)
    {
        Node current = root;
        while (current != null)
        {
            Console.Write(current.Value + " -> ");
            if (value < current.Value)
                current = current.Left;
            else if (value > current.Value)
                current = current.Right;
            else
                break;
        }

        if (current == null)
            Console.WriteLine("Valor no encontrado.");
        else
            Console.WriteLine("Valor encontrado: " + current.Value);
    }

    // Método para calcular la altura del árbol
    public int Height(Node root)
    {
        if (root == null)
            return -1; // -1 si contamos desde los niveles, 0 si contamos los nodos.

        int leftHeight = Height(root.Left);
        int rightHeight = Height(root.Right);

        return Math.Max(leftHeight, rightHeight) + 1;
    }

    // Método para contar las hojas del árbol
    public int CountLeaves(Node root)
    {
        if (root == null)
            return 0;
        if (root.Left == null && root.Right == null)
            return 1;

        return CountLeaves(root.Left) + CountLeaves(root.Right);
    }
}

class Program
{
    static void Main()
    {
        BinaryTree tree = new BinaryTree();
        tree.Insert(5);
        tree.Insert(3);
        tree.Insert(7);
        tree.Insert(2);
        tree.Insert(4);
        tree.Insert(9);

        // Mostrar el árbol con los recorridos
        Console.WriteLine("Recorrido Pre-Orden:");
        tree.PreOrder(tree.Root);
        Console.WriteLine();

        Console.WriteLine("Recorrido In-Orden:");
        tree.InOrder(tree.Root);
        Console.WriteLine();

        Console.WriteLine("Recorrido Post-Orden:");
        tree.PostOrder(tree.Root);
        Console.WriteLine();

        // Buscar un valor en el árbol
        int searchValue = 4;
        Console.WriteLine($"\nBuscar el valor {searchValue}:");
        tree.PrintSearchPath(tree.Root, searchValue); // 5 -> 3 -> 4 -> Valor encontrado: 4

        searchValue = 6;
        Console.WriteLine($"\nBuscar el valor {searchValue}:");
        tree.PrintSearchPath(tree.Root, searchValue); // 5 -> 7 -> Valor no encontrado.

        // Calcular la altura del árbol
        Console.WriteLine("\nAltura del árbol: " + tree.Height(tree.Root)); // Salida esperada: 2

        // Contar las hojas del árbol
        Console.WriteLine("\nNúmero de hojas en el árbol: " + tree.CountLeaves(tree.Root)); // Salida esperada: 3

        // Eliminar un nodo y mostrar el árbol nuevamente
        int deleteValue = 7;
        tree.Delete(tree.Root, deleteValue);
        Console.WriteLine($"\nEliminar el valor {deleteValue}:");
        tree.InOrder(tree.Root);
        Console.WriteLine();
    }
}
