class OrderConfirmationPage {

    confirmOrder() {
        cy.get('h2.complete-header')
        .should('be.visible')
        .should('have.text', 'Thank you for your order!')
        //.
        //.should('have.')
        //.should
    }

}

export default OrderConfirmationPage