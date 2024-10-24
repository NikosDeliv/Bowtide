﻿using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;

namespace Bowtide.Content.Items.Weapons
{
    internal class SkywardensBow : ModItem
    {
        public override void SetDefaults()
        {
            Item.damage = 60; // Set the bow's damage
            Item.DamageType = DamageClass.Ranged;
            Item.width = 20;
            Item.height = 40;
            Item.useTime = 20;
            Item.useAnimation = 20;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.noMelee = true;
            Item.knockBack = 4f;
            Item.value = Item.buyPrice(gold: 5);
            Item.rare = ItemRarityID.LightPurple;
            Item.UseSound = SoundID.Item5;
            Item.shoot = ProjectileID.WoodenArrowFriendly;
            Item.shootSpeed = 12f;
            Item.useAmmo = AmmoID.Arrow;
            Item.scale = 0.8f;
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.SoulofFlight, 10);
            recipe.AddRecipeGroup("Bowtide:MythrilOrichalcumBar", 12); // Requires 12 bars of either Mythril or Orichalcum
            recipe.AddIngredient(ItemID.Feather, 5); 
            recipe.AddIngredient(ItemID.SunplateBlock, 10);
            recipe.AddRecipeGroup("Bowtide:MythrilOrichalcumAnvil");
            recipe.Register();
        }
    }
}
