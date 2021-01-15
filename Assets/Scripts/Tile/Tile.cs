using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Tile : Object
{
    [SerializeField]
    private int posX, posY, posZ;

    GameObject tile;
    [SerializeField]
    Sprite[] tileSprite;
    [SerializeField]
    SpriteRenderer tileSpriteRend;

    public Unit _unitObj;
    public Built _builtObj;
    public Tile[] tileneighbor = new Tile[6];
    void Start()
    {
        tile = this.GetComponent<GameObject>();
        if (!this._code.Equals((int)BUILT.CASTLE))
        {
            if (this._code >= (int)TILE.GRASS_START) { this.tileSpriteRend.sprite = tileSprite[this._code - (int)TILE.GRASS_START]; }
            else if (this._code > (int)TILE.CAN_MOVE && this._code < (int)BUILT.CASTLE) { this.tileSpriteRend.sprite = tileSprite[this._code - 1]; }
            else if (this._code < (int)TILE.CAN_MOVE) { this.tileSpriteRend.sprite = tileSprite[this._code]; }
        }
        _name = "독도는";
        _desc = "우리땅";
    }

    /**
     * @brief 타일의 posX,posY값  설정 또는 값 알아오기
     */
    public int PosX
    {
        get
        {
            return posX;
        }
        set
        {
            posX = value;
        }
    }

    public int PosY
    {
        get
        {
            return posY;
        }
        set
        {
            posY = value;
        }
    }
    public int PosZ
    {
        get
        {
            return posZ;
        }
        set
        {
            posZ = value;
        }
    }

    /**
     * @brief 타일이 어디있는지 Vec2 알아오기
     */
    public Vector2 GetTileVec2
    {
        get
        {
            return new Vector2(this.transform.position.x, this.transform.position.y);
        }
    }


    public static bool isEmptyTile(Tile t)
    {
        if (t._unitObj == null && t._builtObj == null && t._code < (int)TILE.CAN_MOVE)
            return true;
        return false;
    }
}
