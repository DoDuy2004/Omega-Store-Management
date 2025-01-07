﻿namespace OmegaStore.Models
{
    public class Cart
    {
        public List<CartItem> CartItems { get; set; } = new List<CartItem>();
    }

    public class CartItem
    {
        public int CartItemId { get; set; }
        public Product Product { get; set; } = null!;

        public int Quantity { get; set; }
    }
}
