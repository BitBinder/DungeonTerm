using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BSP  {

    public int MIN_LEAF_SIZE = 5;
    public int x, y, width, height;
    public BSP leftChild;
    public BSP rightChild;
    public Rect room;
    public List<Rect> halls;

    public BSP(int _x, int _y, int _width, int _height)
    {
        x = _x;
        y = _y;
        width = _width;
        height = _height;
    }

    public bool Split()
    {
        if (leftChild != null || rightChild != null)
        {
            return false;
        }

        //if width is >25% larger than height we split vert.
        //if height is >25% larger than width we split horiz.

        var splitH = Random.value > 0.5f;
        if (width > height && height / width >= 0.05)
        {
            splitH = false;
        }
        else if (height > width && width / height >= 0.05)
        {
            splitH = true;
        }

        int max = (splitH ? height : width) - MIN_LEAF_SIZE;
        if (max <= MIN_LEAF_SIZE)
        {
            return false;
        }

        var split = Random.Range(MIN_LEAF_SIZE, max);

        if (splitH)
        {
            leftChild = new BSP(x, y, width, split);
            rightChild = new BSP(x, y + split, width, height - split);
        }
        else
        {
            leftChild = new BSP(x, y, split, height);
            rightChild = new BSP(x + split, y, width - split, height);
        }
        return true;
    }

    public Rect GetRoom()
    {
        if (room != null)
        {
            return room;
        }

        else
        {
            Rect lroom = new Rect();
            Rect rroom = new Rect();
            if (leftChild != null)
            {
                lroom = leftChild.GetRoom();
            }
            if (rightChild != null)
            {
                rroom = rightChild.GetRoom();
            }
            if (lroom == null && rroom == null)
            {
                return new Rect();
            }
            else if (rroom == null)
            {
                return lroom;
            }
            else if (lroom == null)
            {
                return rroom;
            }
            else if (Random.value > .5f)
            {
                return lroom;
            }
            else 
            {
                return rroom;
            }

        }
    }

    public void CreateRooms()
    {
        if (leftChild != null || rightChild != null)
        {
            // this leaf has been split, so go into the children leafs
            if (leftChild != null)
            {
                leftChild.CreateRooms();
            }
            if (rightChild != null)
            {
                rightChild.CreateRooms();
            }

            // if there are both left and right children in this leaf, create a hallway between them
            if (leftChild != null && rightChild != null)
            {
                //createHall(leftChild.getRoom(), rightChild.getRoom());
            }

        }
        else
        {
            Vector2 roomSize;
            Vector2 roomPos;

            roomSize = new Vector2(Random.Range(3, width - 2), Random.Range(3, height - 2));
            roomPos = new Vector2(Random.Range(1, width - roomSize.x - 1), Random.Range(1, height - roomSize.y - 1));
            room = new Rect(x + roomPos.x, y + roomPos.y, roomSize.x, roomSize.y);

        }
    }

    public void CreateHall(Rect l, Rect r)
    {

    }
}
