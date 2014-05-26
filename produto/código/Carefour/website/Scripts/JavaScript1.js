<script type="text/javascript">
        
    function removerProduto(link) {

        var result = confirm("Deseja excluir esse produto?");
        if (result) {
            var row = link.parentNode.parentNode;
            row.parentNode.removeChild(row);
            return true;
        } else {
            return false;
        }
    }


</script>